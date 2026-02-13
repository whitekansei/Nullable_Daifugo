using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    [SerializeField]
    private GameObject nameInputFieldObj;
    [SerializeField]
    private GameObject newGameButtonObj;
    [SerializeField]
    private GameObject enterRoomButtonObj;
    [SerializeField]
    private GameObject backButtonObj;
    [SerializeField]
    public GameObject howToPlayButtonObj;
    [SerializeField]
    private GameObject howToPlayPanelObj;
    [SerializeField]
    private OnlineMatchingManager onlineMatchingManager;
    private TMP_InputField nameInputField;
    private Button enterRoomButton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Updateの中でGetComponentを行うと処理が重くなる可能性があるので避ける
        enterRoomButton = enterRoomButtonObj.GetComponent<Button>();
        nameInputField = nameInputFieldObj.GetComponent<TMP_InputField>();
    }

    // Update is called once per frame
    void Update()
    {
        //名前入力欄に有効な値が入力されていたなら、入室ボタンを活性にする
        if (nameInputFieldObj.activeSelf && nameInputField.text != "" && nameInputField.text.Length <= 8)
        {
            onlineMatchingManager.SetMyPlayerName(nameInputField.text);
            enterRoomButton.interactable = true;
        }
        else
        {
            enterRoomButton.interactable = false;
        }
    }

    public void OnClickNewGameButton()
    {
        enterRoomButtonObj.SetActive(true);
        backButtonObj.SetActive(true);
        nameInputFieldObj.SetActive(true);
        howToPlayButtonObj.SetActive(false);
        newGameButtonObj.SetActive(false);
    } 
    public void OnClickEnterRoomButton()
    {
        onlineMatchingManager.CreateOrEnterRoom();
        SceneManager.LoadScene("GameScene");
    }
    public void OnClickBackButon()
    {
        howToPlayPanelObj.SetActive(false);
        enterRoomButtonObj.SetActive(false); 
        backButtonObj.SetActive(false);
        nameInputFieldObj.SetActive(false);
        newGameButtonObj.SetActive(true);
        howToPlayButtonObj.SetActive(true);
    }
    public void OnClickHowToPlayButton()
    {
        howToPlayPanelObj.SetActive(true);
        backButtonObj.SetActive(true);
        newGameButtonObj.SetActive(false);
        howToPlayButtonObj.SetActive(false);
    }
}
