using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public Text scoreText;

    int currentScore;

    void Awake()
    {
        instance = this;
        //UPDATE UI
        UpdateUI();
    }

    public void AddScore(int score)
    {
        currentScore += score;
        //UPDATE UI
        UpdateUI();
    }

    void UpdateUI()
    {
        scoreText.text = "Score: " + currentScore.ToString("D5");
    }
}
