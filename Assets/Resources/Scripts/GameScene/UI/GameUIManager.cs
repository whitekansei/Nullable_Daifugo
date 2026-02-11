using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameUIManager : MonoBehaviour
{
    [SerializeField]
    private GameManager gameManager;
    [SerializeField]
    private GameObject getReadyButtonObj;
    [SerializeField]
    private GameObject getReadyButtonTextObj;
    [SerializeField]
    private GameObject cardButtonPrefab;
    [SerializeField]
    private GameObject otherPlayerInfoPrefab;
    [SerializeField]
    private GameObject logPanelObj;
    [SerializeField]
    private GameObject logPanelTextObj;
    [SerializeField]
    private GameObject lastCardListObj;
    [SerializeField]
    private GameObject lastCardListText;
    [SerializeField]
    private GameObject field;
    [SerializeField]
    private GameObject handScrollViewContent;
    [SerializeField]
    private GameObject otherPlayerInfoScrollViewContent;
    [SerializeField]
    private GameObject myTurnPanel;
    [SerializeField]
    private GameObject putCardButton;
    [SerializeField]
    private GameObject putCardButtonText;
    [SerializeField]
    private GameObject passButton;
    [SerializeField]
    private GameObject passButtonText;
    [SerializeField]
    private GameObject dimWhenChoosingPanel;
    [SerializeField]
    private GameObject gameFinishPanelInfo;
    [SerializeField]
    private MyPlayerInfoUIManager myPlayerInfoUIManager;
    [SerializeField]
    private MyTurnActionController myTurnActionController;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
