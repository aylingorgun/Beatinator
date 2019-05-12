using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateHolesandWalls : MonoBehaviour
{
    public GameObject[] HolesAndWalls;
    private int xPos;
    private int zPos;

    private int holeCount;

    private int randomIndex;

    void Start()
    {
        holeCount = 0;
        Generator();
        //StartCoroutine(HoleDrop());   
    }

    //Duped and don't know which one is better.
    IEnumerator HoleDrop()
    {
        while (holeCount < 10)
        {
            //Hopefully prevents spawn overlap
            int maxRetries = 25;
            while (true)
            {
                xPos = Random.Range(-2, 3) * 2;
                zPos = Random.Range(-7, 8) * 2 + System.Convert.ToInt32(transform.position.z);
                if (Physics.OverlapSphere(new Vector3(xPos, 1, zPos), 0.8f).Length == 0)
                    break;
                maxRetries--;
                if (--maxRetries == 0)
                    yield return null;
            }

            //Vectorized
            Instantiate(HolesAndWalls[randomIndex], new Vector3(xPos, HolesAndWalls[randomIndex].transform.position.y, zPos), HolesAndWalls[randomIndex].transform.rotation);
            yield return null;
            holeCount++;
            randomIndex = Random.Range(0, 2);
        }
    }

    private void Generator()
    {
        while (holeCount < 10)
        {
            //Hopefully prevents spawn overlap
            int maxRetries = 25;
            while (true)
            {
                xPos = Random.Range(-2, 3) * 2;
                zPos = Random.Range(-7, 8) * 2 + System.Convert.ToInt32(transform.position.z);
                if (Physics.OverlapSphere(new Vector3(xPos, 1, zPos), 0.8f).Length == 0)
                    break;
                maxRetries--;
                if (--maxRetries == 0)
                    return;
            }

            //Vectorized
            Instantiate(HolesAndWalls[randomIndex], new Vector3(xPos, HolesAndWalls[randomIndex].transform.position.y, zPos), HolesAndWalls[randomIndex].transform.rotation);
            holeCount++;
            randomIndex = Random.Range(0, 2);
        }
    }
}
