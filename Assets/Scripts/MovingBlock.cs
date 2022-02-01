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

    public Transform[] bottomPoints;

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
        foreach (var bottomPoint in bottomPoints)
        {
            if (CheckForCollision(bottomPoint, transform.position))
            {
                return;
            }
        }

        var rb = GetComponent<Rigidbody>();
        var currentPosition = rb.position;
        rb.MovePosition(new Vector3(x, Mathf.RoundToInt(y), currentPosition.z));
    }

    private bool CheckForCollision(Transform bottomPoint, Vector3 objectZeroPoint)
    {
        var currentPosition = bottomPoint.position;
        var desiredPosition = new Vector3(x, Mathf.RoundToInt(y), objectZeroPoint.z) + bottomPoint.localPosition;

        Vector3 direction = desiredPosition - currentPosition;
        Ray ray = new Ray(currentPosition, direction);
        return Physics.Raycast(ray, out _, direction.magnitude);
    }
}