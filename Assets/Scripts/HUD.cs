using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class HUD : MonoBehaviour
{
    static int score = 0;

    public TMP_Text scorebot;
    public GameObject fullHearts;
    //public Image hpbar;

    void Start()
    {
        //Debug.Log(score);
        scorebot.text = score + " pts";
    }

    void Update()
    {
        scorebot.text = score + " pts";
        //UpdateHP();
    }

    static public void UpdateScore(int points)
    {
        score += points;
        //Debug.Log(score);
    }

    public void UpdateHP()
    {
        fullHearts.transform.GetChild(Player.hp).GetComponent<SpriteRenderer>().enabled = false;
        //hpbar.fillAmount = Player.hp / 100;
    }
}