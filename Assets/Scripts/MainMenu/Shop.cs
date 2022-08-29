using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shop : MonoBehaviour
{
    public TMP_Text coinsBot;

    private int coins;

    void Start()
    {
        coins = PlayerPrefs.GetInt("CurrentCoinsCount");
        coinsBot.text = coins + "";
    }

    public void BuyUpgrade(int cost)
    {
        if (cost <= coins)
        {
            coins -= cost;
            coinsBot.text = coins + "";
            PlayerPrefs.SetInt("CurrentCoinsCount", coins);
        }
    }
}