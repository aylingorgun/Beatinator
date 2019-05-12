using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingEnemy : MonoBehaviour
{
    //Transform of player
    private Transform playerT;
    //Which axis to move on
    private bool moveAlongX;
    //Positive or negative movement
    private int sign;

    void Start()
    {
        playerT = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    public void MoveTowards()
    {
        if (System.Math.Abs(playerT.position.x - transform.position.x) >= System.Math.Abs(playerT.position.z - transform.position.z))
            moveAlongX = true;
        else
            moveAlongX = false;

        if (moveAlongX)
        {
            sign = System.Math.Sign(playerT.position.x - transform.position.x);
            transform.position += Vector3.right * 2 * sign;    
        }
        else
        {
            sign = System.Math.Sign(playerT.position.z - transform.position.z);
            transform.position += Vector3.forward * 2 * sign;
        }
    }

    //May have to implement 4 more colliders like the player object to disable clipping through walls
    //Also implement onCollision enter for holes. And destroy fallen objects.
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            FindObjectOfType<Move>().Death();
    }
}
