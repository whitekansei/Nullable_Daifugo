using UnityEngine;
using TMPro;
using System.Collections.Generic;
public class Test : MonoBehaviour
{
    private GameObject exampleObj;
    private GameObject examplePrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //↑と書いているように、Start関数はシーンのロード時に一度だけ呼ばれます

    void Start()
    {
        var testGM = new GameManager();  //あまりよろしくない
        var testObj = new GameObject();  //これもあまりよろしくない
        var testIntList = new List<int>();  //これはOK
        testGM = testObj.GetComponent<GameManager>(); //スクリプトやコンポーネントの取得にはGetComponent()を使います

        //prefabからGameObjectを実際に創り出すにはInstantiateを使います
        //↓のコードはexampleObjの位置に、exampleObjの子オブジェクトとして生成します
        var prefab = Instantiate(examplePrefab, exampleObj.transform);

        exampleObj.SetActive(false); //exampleObjを非表示にします

        var exampleTMPro = exampleObj.GetComponent<TextMeshProUGUI>(); //exampleObjのTextMeshProUGUIコンポーネントを取得し
        exampleTMPro.text = "Hello, World! "; //テキストの内容を変更します

        //その他、秋吉が書いたTitleManagerやOnlineMatchingManagerを参考にしてください（拙い部分も多いですが。。。）
    }

    // Update is called once per frame
    //↑と書いているように、Update関数は毎フレーム呼ばれます。60fpsの環境なら1秒に60回。
    //StartとUpdateはあっても中身が空なら処理が重くなることはありませんが、不要なら消去してください
    void Update()
    {

    }


    public enum Kaku_Team
    {
        //enumをint型に紐づけることが可能です
        Kaku=0, Murata=1, Wakasa=2, Akiyoshi=3
    }
    public void enumText()
    {
        //enumをintにキャストすることで紐づけた値を取得出来ます
        int test = (int) Kaku_Team.Akiyoshi;
        if (test == 3)
        {
            //Unityのconsoleウィンドウに出力できます
            Debug.Log("これは秋吉");
            return;
        }
    }
}

