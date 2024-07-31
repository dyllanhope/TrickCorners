using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] int ScoreIncrementNum = 1;

    private int score;

    static ScoreManager instance;

    private void Awake()
    {
        ManageSingleton();
    }
    void ManageSingleton()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        score = 0;
    }

    public string GetCurrentScore()
    {
        return score.ToString("00");
    }

    public void IncreaseScore()
    {
        score += ScoreIncrementNum;
    }
    public void ResetScore()
    {
        score = 0;
    }
}
