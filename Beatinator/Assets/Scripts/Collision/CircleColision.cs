using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleColision : MonoBehaviour
{
    private static bool canMove;
    private float timer;
    public GameObject audioS;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            audioS.SetActive(true);
            canMove = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (canMove)
            timer = 0.3f;
    }

    void Start()
    {
        audioS.GetComponent<AudioSource>();
        audioS.SetActive(false);

        canMove = false;
    }

    //Is used for testing props
    //without movement impairments
    private static bool debug = false;
    
    //Is used in the Move class
    //to limit movement to once per beat
    public static bool TryMoving()
    {
        //Used for debugging!
        if (debug)
            return true;

        if (canMove)
        {
            canMove = false;
            return true;
        }
        return false;
    }

    private void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            if(timer <= 0)
                canMove = false;
        }    
    }

}
