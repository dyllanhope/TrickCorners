using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float movementSpeed = 1f;

    private int xDir = -1;
    private int yDir = -1;

    private Vector2 direction;

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
        xDir = xDir * -1;
        direction = new Vector2(xDir, yDir).normalized;
    }
}