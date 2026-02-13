using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private OnlineMatchingManager onlineMatchingManager;
    [SerializeField]
    private RuleManager ruleManager;
    [SerializeField]
    private GameNetworkManager gameNetworkManager;
    [SerializeField]
    private GameUIManager gameUIManager;
    [SerializeField]
    private TurnManager turnManager;
    [SerializeField]
    private LastCardListManager lastCardListManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClickReadyButton()
    {
        onlineMatchingManager.SetReadyProperty();
    }
    public void UpdateReadyButtonText(int readyPlayerNum, int allPlayerNum)
    {
        gameUIManager.ChangeGetReadyButtonText(readyPlayerNum, allPlayerNum);
    }
    public void GameStart()
    {
        //自分がホストなら、ゲーム開始処理を行う
        if (onlineMatchingManager.IsHostPlayer())
        {
            Debug.Log("ゲームスタート！");
            gameUIManager.ChangeActiveOfGetReadyButton(false); //仮置き。ここではなくGameNetWorkManagerに書いて全員に展開する
        }
    }
}
