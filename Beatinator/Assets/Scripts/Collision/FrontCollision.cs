using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontCollision : MonoBehaviour
{
    public static bool isFrontAvailable = true;

    private void OnTriggerEnter(Collider other)
    {
        isFrontAvailable = false;
    }

    private void OnTriggerStay(Collider other)
    {
        isFrontAvailable = false;
    }

    private void OnTriggerExit(Collider other)
    {
        isFrontAvailable = true;
    }
}
