﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colision : MonoBehaviour
{
    public static bool flag;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            flag = true;
        }
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        flag = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        flag = false;
    }
}
