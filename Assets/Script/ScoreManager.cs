using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] int ScoreIncrementNum = 1;

    [SerializeField] TextMeshProUGUI scoreText;

    private int score;

    private void Start()
    {
        score = 0;
        scoreText.text = score.ToString("00");
    }

    public string GetCurrentScore() { return score.ToString(); }

    public void IncreaseScore()
    {
        score += ScoreIncrementNum;

        scoreText.text = score.ToString("00");
    }

}
