using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Move : MonoBehaviour
{
    //Step size
    public float step = 2f;
    
    //All side colliders - unused?
    //public BoxCollider colliderFront;
    //public BoxCollider colliderBack;
    //public BoxCollider colliderLeft;
    //public BoxCollider colliderRight;
    
    //Dummy variable to track faulty movements
    private int fault = 0;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Has collided with " + other.attachedRigidbody.tag + "\nFault: " + fault);
    }

    void Update()
    {
      
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (LeftCollision.isLeftAvailable)
                transform.position += Vector3.left * step;
            else
                fault++;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (RightCollision.isRightAvailable)
                transform.position += Vector3.right * step;
            else
                fault++;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (FrontCollision.isFrontAvailable)
                transform.position += Vector3.forward * step;
            else
                fault++;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (BackCollision.isBackAvailable)
                transform.position += Vector3.back * step;
            else
                fault++;
        }
    }
}