using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MaxScore : MonoBehaviour
{
    public TMP_Text maxScoreBot;

    void Start()
    {
        maxScoreBot.text = PlayerPrefs.GetInt("MaxScore") + "";
    }
}
