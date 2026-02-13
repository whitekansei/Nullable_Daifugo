using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;
using UnityEngine.SceneManagement;

public class OnlineMatchingManager : MonoBehaviourPunCallbacks
{
    private static string myPlayerName;
    private List<string> playerNamesList = new List<string>();
    private OnlineMatchingManager onlineMatchingManager;

    private void Awake()
    {
        if (onlineMatchingManager == null)
        {
            onlineMatchingManager = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }

    public void SetMyPlayerName(string name)
    {
        myPlayerName = name;
    }
    public string GetMyPlayerName()
    {
        return myPlayerName;
    }

    public void CreateOrEnterRoom()
    {
        // PhotonServerSettingsの設定内容を使ってマスターサーバーへ接続する
        PhotonNetwork.NickName = myPlayerName;
        PhotonNetwork.ConnectUsingSettings();
    }

    // マスターサーバーへの接続が成功した時に呼ばれるコールバック
    public override void OnConnectedToMaster()
    {
        // ランダムマッチング
        PhotonNetwork.JoinRandomRoom();
    }

    // 失敗した場合
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        PhotonNetwork.CreateRoom(null, new RoomOptions() { MaxPlayers = 8 }, TypedLobby.Default);
    }


    // ゲームサーバーへの接続が成功した時に呼ばれるコールバック
    public override void OnJoinedRoom()
    {
        Debug.Log("ルーム入室成功！ プレイヤー数: " + PhotonNetwork.CurrentRoom.PlayerCount);
    }
    // 他のプレイヤーが入室した時
    public override void OnPlayerEnteredRoom(Photon.Realtime.Player newPlayer)
    {
        Debug.Log("新しいプレイヤーが参加: " + newPlayer.NickName);
        UpdatePlayerList();
    }

    // 他のプレイヤーが退出した時
    public override void OnPlayerLeftRoom(Photon.Realtime.Player otherPlayer)
    {
        Debug.Log("プレイヤー退出: " + otherPlayer.NickName);
        UpdatePlayerList();
    }
    public void UpdatePlayerList()
    {
        foreach (var p in PhotonNetwork.CurrentRoom.Players.Values.OrderBy(x => x.ActorNumber))
        {
            playerNamesList.Add(p.NickName);
        }
    }

    public void SetReadyProperty()
    {
        // 自分のプレイヤーにReadyフラグをセット
        Hashtable props = new Hashtable();
        props["Ready"] = true;
        PhotonNetwork.LocalPlayer.SetCustomProperties(props);
    }

    // 誰かのプロパティが更新されたら呼ばれる
    public override void OnPlayerPropertiesUpdate(Player targetPlayer, Hashtable changedProps)
    {
        if (changedProps.ContainsKey("Ready"))
        {
            //全プレイヤーが準備完了ボタンを押したかチェック
            int readyPlayerNum = CheckAllPlayersReady();
            //UI更新処理
            GameObject gameManagerObj = GameObject.Find("GameObject");
            if (gameManagerObj)
            {
                var gm = gameManagerObj.GetComponent<GameManager>();
                if (gm)
                {
                    gm.UpdateReadyButtonText(readyPlayerNum, CountPlayer());
                }
            }
                    
        }
    }

    public int CheckAllPlayersReady()
    {
        int readyPlayerNum = 0;
        foreach (Player p in PhotonNetwork.PlayerList)
        {
            if (p.CustomProperties.TryGetValue("Ready", out object isReady))
            {
                if (!(bool)isReady) continue;  
            }
            else
            {
                continue; // Readyフラグ自体がない人も未準備
            }
            readyPlayerNum++;
        }
        if (PhotonNetwork.PlayerList.Count() != readyPlayerNum || PhotonNetwork.PlayerList.Count() == 0)　//ここは本番ではCount() == 1 とすること！！
        {
            return readyPlayerNum; //準備完了じゃないプレイヤーがいるかぼっちプレイの場合、人数を返して中断
        }

        // ここまで来たら全員準備完了！
        GameObject gameManagerObj = GameObject.Find("GameManager");
        if (gameManagerObj)
        {
            var gm = gameManagerObj.GetComponent<GameManager>();
            if (gm) 
            {
                gm.GameStart();
            }
        }
        return 1;
    }
    public void BackTitle()
    {
        if (PhotonNetwork.InRoom)
        {
            PhotonNetwork.LeaveRoom(); // 正しく部屋を抜ける
        }
        else
        {
            SceneManager.LoadScene("TitleScene");
        }
    }
    // ルーム退出完了時に呼ばれる
    public override void OnLeftRoom()
    {
        SceneManager.LoadScene("TitleScene");
    }
    public void NewGame()
    {
        if (!PhotonNetwork.InRoom) return;

        // 自分のReadyを解除
        Hashtable props = new Hashtable();
        props["Ready"] = false;
        PhotonNetwork.LocalPlayer.SetCustomProperties(props);

        // MasterClientがゲーム状態を初期化
        if (PhotonNetwork.IsMasterClient)
        {
            ResetGameState();
        }
    }
    void ResetGameState()
    {
        // 全員の Ready を消す
        foreach (Player p in PhotonNetwork.PlayerList)
        {
            Hashtable props = new Hashtable();
            props["Ready"] = false;
            p.SetCustomProperties(props);
        }

    }
    public bool IsHostPlayer()
    {
        return PhotonNetwork.IsMasterClient;
    }
    public int CountPlayer()
    {
        return PhotonNetwork.PlayerList.Count();
    }
}
