using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform target;

    //Movement speed of camera.
    public float smoothMovementSpeed = 0.01f;

    //Rotation speed of camera.
    //Messes up if too small. I don't know why.
    public float smoothRotationSpeed = 0.01f;
    public Vector3 offset;

    //Desired position of camera.
    private Vector3 desiredPosition;

    //Vector of the point the camera rotates from.
    private Vector3 quatBefore;

    //Vector of the point the camera rotates to.
    private Vector3 quatAfter;
    
    private void Start()
    {
        //Default values
        target = GameObject.FindGameObjectWithTag("Player").transform;

        //Camera position starts from target position + offset
        transform.position = target.position + offset;
        desiredPosition = transform.position;

        //Camera points to target
        quatBefore = target.position;
        quatAfter = quatBefore;

    }

    void Update()
    {
        //Set where to move the camera to
        desiredPosition.Set(offset.x, offset.y, target.position.z + offset.z);

        //Set where to point the camera to
        quatBefore.Set(quatBefore.x, quatBefore.y, target.position.z);

        //Rotate the camera
        quatAfter = Vector3.Lerp(quatAfter, quatBefore, smoothRotationSpeed);
        transform.LookAt(quatAfter);

        //Move the camera
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition , smoothMovementSpeed);
        transform.position = smoothedPosition;
    }
}
