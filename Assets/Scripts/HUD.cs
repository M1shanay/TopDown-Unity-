using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class HUD : MonoBehaviour
{
    static int score = 0;

    public TMP_Text scorebot;
    public static GameObject fullHearts;

    void Start()
    {
        fullHearts = GameObject.Find("FullHearts");
        scorebot.text = score + " pts";
    }

    void Update()
    {
        scorebot.text = score + " pts";
    }

    static public void UpdateScore(int points)
    {
        score += points;
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