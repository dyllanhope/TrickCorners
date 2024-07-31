using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    [Header("Score")]
    [SerializeField] TextMeshProUGUI scoreText;
    ScoreManager scoreManager;

    void Awake()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
    }
    void Start()
    {
        UpdateScore();
    }
    private void Update()
    {
        UpdateScore();
    }
    public void UpdateScore()
    {
        scoreText.text = scoreManager.GetCurrentScore();
    }
}
