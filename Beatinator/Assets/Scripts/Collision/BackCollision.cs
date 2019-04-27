using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackCollision : MonoBehaviour
{
    public static bool isBackAvailable = true;

    private void OnTriggerEnter(Collider other)
    {
        isBackAvailable = false;
    }

    private void OnTriggerExit(Collider other)
    {
        isBackAvailable = true;
    }
}
