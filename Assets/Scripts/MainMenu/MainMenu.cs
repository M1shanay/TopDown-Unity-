using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject ShopPanel;
    public GameObject Battle;

    public void ShowShopPanel()
    {
        ShopPanel.SetActive(!ShopPanel.activeSelf);
    }

    public void PlayGame()
    {
        Battle.SetActive(true);
        gameObject.SetActive(false);
    }
}