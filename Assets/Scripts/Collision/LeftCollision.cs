using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftCollision : MonoBehaviour
{
    public static bool isLeftAvailable = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Wall")
            isLeftAvailable = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Wall")
            isLeftAvailable = false;
    }

    private void OnTriggerExit(Collider other)
    {
        isLeftAvailable = true;
    }

}
