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

    //When the plane prefab changes the exit method gets called
    //so player may drop out unless stay method is also implemented
    private void OnTriggerStay(Collider other)
    {
        isBackAvailable = false;
    }

    private void OnTriggerExit(Collider other)
    {
        isBackAvailable = true;
    }
}
