using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float movementSpeed = 1f;

    private int xDir = -1;
    private int yDir = -1;

    private Vector2 direction;

    private bool lastFlipX = false;
    private bool isReversed = false;

    SpawnPointManager spawnPointManager;
    ScoreManager scoreManager;
    LevelManager levelManager;

    private void Awake()
    {
        spawnPointManager = FindObjectOfType<SpawnPointManager>();
        scoreManager = FindObjectOfType<ScoreManager>();
        levelManager = FindObjectOfType<LevelManager>();
    }

    private void Start()
    {
        direction = new Vector2(xDir, yDir).normalized;
    }

    void Update()
    {
        transform.Translate(direction * movementSpeed * Time.deltaTime);
    }

    private void OnFlip()
    {
        if (!isReversed)
        {
            if (lastFlipX)
            {
                yDir = yDir * -1;
                lastFlipX = false;
            }
            else
            {
                xDir = xDir * -1;
                lastFlipX = true;
            }
        }
        else
        {
            if (lastFlipX)
            {
                xDir = xDir * -1;
                lastFlipX = false;
            }
            else
            {
                yDir = yDir * -1;
                lastFlipX = true;
            }
        }
        UpdateDirection();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        scoreManager.IncreaseScore();
        movementSpeed += 0.1f;
        ReverseDir();
        Destroy(collision.gameObject);
        spawnPointManager.SpawnObject();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
        levelManager.EndGame();
    }

    private void ReverseDir()
    {
        yDir = yDir * -1;
        xDir = xDir * -1;
        isReversed = !isReversed;
        UpdateDirection();
    }

    private void UpdateDirection()
    {
        direction = new Vector2(xDir, yDir).normalized;
    }
}