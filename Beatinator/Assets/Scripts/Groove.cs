using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Groove : MonoBehaviour
{

    /* 
        This is the class for visual beat meter.     
    */


    //X position to move
    private float distance = 5.0f;
    //Our path complition time
    public float timeInterval = 60.0f;
    // Our value to multiply with vector3.right
    private float speed;

    private float timeLeft = 1.0f;
    Vector3 idle_position;

    public Transform target;
    public Vector3 offset = new Vector3(0f, 0, 0f);

    void Start()
    {
        //starting position
        idle_position.Set(-5.0f, 1.0f, - 2.0f);

        // X = v . t
        speed = distance / timeInterval;
    }

    void FixedUpdate()
    {
        timeLeft -= Time.deltaTime;
        transform.position += Vector3.right * speed;
        
        if (timeLeft < 0.0f)
        {
            Debug.Log(timeLeft);
            //go back to initial state
            timeLeft = 1.0f;
            transform.SetPositionAndRotation(idle_position, Quaternion.identity);

            transform.position = target.position + offset;
        }

    }
}
