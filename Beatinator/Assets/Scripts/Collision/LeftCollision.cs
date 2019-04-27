using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftCollision : MonoBehaviour
{
    public static bool isLeftAvailable = true;

    private void OnTriggerEnter(Collider other)
    {
        isLeftAvailable = false;
    }

    private void OnTriggerExit(Collider other)
    {
        isLeftAvailable = true;
    }

}
