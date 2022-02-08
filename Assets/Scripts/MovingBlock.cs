using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBlock : MonoBehaviour
{
    public float y;
    public int x;
    public float fallingSpeed = 1f;
    public float quickFallingSpeed = 5f;

    public PlayingArea playingArea;

    public Shape shape;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            x -= 1;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            x += 1;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            y -= quickFallingSpeed * Time.deltaTime;
        }
        else
        {
            y -= fallingSpeed * Time.deltaTime;
        }
    }

    // Runs 60 times per second
    private void FixedUpdate()
    {
        var rb = GetComponent<Rigidbody>();
        var currentPosition = rb.position;
        var currentX = Mathf.RoundToInt(currentPosition.x);
        var currentY = Mathf.RoundToInt(currentPosition.y);
        var newX = x;
        var newY = Mathf.RoundToInt(y);

        playingArea.RemoveShape(currentX, currentY, shape);

        if (playingArea.CanAddShape(newX, newY, shape))
        {

            Vector3 newPosition = new Vector3(newX, newY, currentPosition.z);
            rb.MovePosition(newPosition);

            playingArea.AddShape(newX, newY, shape);
        }
        else
        {
            playingArea.AddShape(currentX, currentY, shape);
            x = currentX;
            y = currentY;
        }
    }

}