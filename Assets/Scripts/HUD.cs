using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class HUD : MonoBehaviour
{
    static int score = 0;
    public TMP_Text scorebot;
    public Image hpbar;
    void Start()
    {
        Debug.Log(score);
        scorebot.text = score + " pts";
    }

    // Update is called once per frame
    void Update()
    {
        scorebot.text = score + " pts";
        UpdateHP();
    }
    static public void UpdateScore(int points)
    {
        score += points;
        Debug.Log(score);
    }
    void UpdateHP()
    {
        hpbar.fillAmount = Player.hp / 100;
    }
}
