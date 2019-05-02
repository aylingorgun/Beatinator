﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleColision : MonoBehaviour
{
    private static bool canMove;
    private float timer;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            canMove = true;

        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (canMove)
            timer = 0.3f;
    }

    void Start()
    {
        canMove = false;
    }
    
    //Is used in the Move class
    //to limit movement to once per beat
    public static bool TryMoving()
    {
        if (canMove)
        {
            canMove = false;
            return true;
        }
        return false;
    }

    private void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            if(timer <= 0)
                canMove = false;
        }    
    }

}