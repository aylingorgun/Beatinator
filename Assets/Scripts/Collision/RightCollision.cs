using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightCollision : MonoBehaviour
{
    public static bool isRightAvailable = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Wall")
            isRightAvailable = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Wall")
            isRightAvailable = false;
    }

    private void OnTriggerExit(Collider other)
    {
        isRightAvailable = true;
    }
}
