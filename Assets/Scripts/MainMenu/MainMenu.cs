using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject ShopPanel;

    private void Start()
    {
        //PlayerPrefs.DeleteAll();
    }

    public void ShowShopPanel()
    {
        ShopPanel.SetActive(!ShopPanel.activeSelf);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
}