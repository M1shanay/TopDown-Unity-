using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Assortment : MonoBehaviour
{
    public Button[] upgrades;
    public TMP_Text[] costs;

    private void Start()
    {
        if (PlayerPrefs.GetInt("CurrentCoinsCount") >= Convert.ToInt64(costs[0].text) && PlayerPrefs.GetString("RocketLaunch") != "Yes")
        {
            upgrades[0].interactable = true;
        }
        if (PlayerPrefs.GetInt("CurrentCoinsCount") >= Convert.ToInt64(costs[1].text) && PlayerPrefs.GetString("DoubleShot") != "Yes")
        {
            upgrades[1].interactable = true;
        }
    }

    public void BuyRocketLaunchUpgrade()
    {
        PlayerPrefs.SetString("RocketLaunch", "Yes");
        upgrades[0].interactable = false;
    }

    public void BuyDoubleShotUpgrade()
    {
        PlayerPrefs.SetString("DoubleShot", "Yes");
        upgrades[1].interactable = false;
    }
}