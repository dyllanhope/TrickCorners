using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    ScoreManager scoreManager;

    private void Awake()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
    }
    public void StartGame()
    {
        SceneManager.LoadScene("MainScene");
        scoreManager.ResetScore();
    }
    public void EndGame()
    {
        SceneManager.LoadScene("EndScene");
        scoreManager.GetCurrentScore();

    }
    public void MainMenu()
    {
        SceneManager.LoadScene("StartScene");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
