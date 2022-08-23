using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class HUD : MonoBehaviour
{
    static int score = 0;
    static int coins = 0;

    public TMP_Text scoreBot;
    public TMP_Text coinsBot;
    public static GameObject fullHearts;

    void Start()
    {
        fullHearts = GameObject.Find("FullHearts");
        scoreBot.text = score + " pts";
        coinsBot.text = coins + "";
    }

    void Update()
    {
        scoreBot.text = score + " pts";
        coinsBot.text = coins + "";
    }

    static public void UpdateScore(int points)
    {
        score += points;
    }

    public static void UpdateCoins(int coin)
    {
        coins += coin;
    }

    public static void UpdateHP_Minus()
    {
        fullHearts.transform.GetChild(Player.hp).GetComponent<SpriteRenderer>().enabled = false;
    }

    public static void UpdateHP_Plus()
    {
        fullHearts.transform.GetChild(Player.hp - 1).GetComponent<SpriteRenderer>().enabled = true;
    }

    public static int GetScore
    {
        get { return score; }
    }
}