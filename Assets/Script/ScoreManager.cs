using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] int ScoreIncrementNum = 1;

    private int score;

    private void Start()
    {
        score = 0;
    }

    public string GetCurrentScore() { return score.ToString(); }

    public void IncreaseScore()
    {
        score += ScoreIncrementNum;
    }

}
