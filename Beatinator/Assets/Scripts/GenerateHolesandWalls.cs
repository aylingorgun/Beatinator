using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateHolesandWalls : MonoBehaviour
{

    public GameObject xMinObj;
    public GameObject xMaxObj;

    public GameObject zMinObj;
    public GameObject zMaxObj;

    public GameObject Hole;
    public int xPos;
    public int zPos;

    public static int holeCount;

    void Start()
    {
        holeCount = 0;
        StartCoroutine(HoleDrop());   
    }

    IEnumerator HoleDrop()
    {
        int xMin = (int)(xMinObj.transform.position.x);
        int xMax = (int)(xMaxObj.transform.position.x);

        int zMin = (int)(zMinObj.transform.position.z);
        int zMax = (int)(zMaxObj.transform.position.z);

        while (holeCount < 10)
        {
            xPos = Random.Range(xMin, xMax+1);
            zPos = Random.Range(zMin, zMax+1);

            Instantiate(Hole, new Vector3(xPos, 1, zPos), Quaternion.identity);

            yield return new WaitForSeconds(0);
            holeCount++;
        }
    }

}
