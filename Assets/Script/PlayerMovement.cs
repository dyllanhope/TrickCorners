using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float movementSpeed = 1f;

    private int xDir = -1;
    private int yDir = -1;

    private Vector2 direction;

    private bool lastFlipX = false;
    private bool isReversed = false;

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

    private void OnFire()
    {
        ReverseDir();
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