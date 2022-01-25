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

        var p = transform.position;
        p.x = x;
        p.y = Mathf.RoundToInt(y);
        transform.position = p;
    }

    // Runs 60 times per second
    private void FixedUpdate()
    {
    }
}
