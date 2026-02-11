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
}
