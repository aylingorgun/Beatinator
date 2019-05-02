﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateHolesandWalls : MonoBehaviour
{

    public GameObject xMinObj;
    public GameObject xMaxObj;

    public GameObject zMinObj;
    public GameObject zMaxObj;

    public GameObject[] HolesAndWalls;
    public int xPos;
    public int zPos;

    public static int holeCount;

    int i;

    int xMin, xMax, zMin, zMax;

    void Start()
    {
        holeCount = 0;
        StartCoroutine(HoleDrop());   
    }

    IEnumerator HoleDrop()
    {
        xMin = (int)(xMinObj.transform.position.x);
        xMax = (int)(xMaxObj.transform.position.x);

        zMin = (int)(zMinObj.transform.position.z);
        zMax = (int)(zMaxObj.transform.position.z);

        while (holeCount < 10)
        {
            xPos = Random.Range(xMin, xMax+1);
            zPos = Random.Range(zMin, zMax+1);

            switch (i)
            {
                case 0:
                    Instantiate(HolesAndWalls[0], new Vector3(xPos, 0.15f, zPos), Quaternion.Euler(0, 180, 0));
                    yield return new WaitForSeconds(0);
                    holeCount++;
                    break;
                case 1:
                    Instantiate(HolesAndWalls[1], new Vector3(xPos, 0.30f, zPos), Quaternion.Euler(105, 0, 0));
                    yield return new WaitForSeconds(0);
                    holeCount++;
                    break;
                default: break;

            }
            i = Random.Range(0, 2);       
        }
    }
}
