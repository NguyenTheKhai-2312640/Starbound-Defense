using UnityEngine;
using TMPro;

public class MoneyManager : MonoBehaviour
{
    [SerializeField] public float currentCoins;
    [SerializeField] private UIUpdater uiUpdater;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        uiUpdater.UpdateCoinUI(this);
    }

    // Update is called once per frame
    // void Update()
    // {
    //     currentCoinsCount.text = currentCoins.ToString();
    // }

    public float RemainingCoinPercentage
    {
        get
        {
            return currentCoins;
        }
    }

    public void AddCoins(float coinAmount)
    {
        currentCoins += coinAmount;
        Debug.Log(currentCoins);
        uiUpdater.UpdateCoinUI(this);
    }
}
