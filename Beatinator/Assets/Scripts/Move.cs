using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class Move : MonoBehaviour
{
    //Step size
    public float step = 2f;
    public float jumpHeight = 0.35f;

    //All side colliders - unused?
    //public BoxCollider colliderFront;
    //public BoxCollider colliderBack;
    //public BoxCollider colliderLeft;
    //public BoxCollider colliderRight;
    
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Has collided with " + other.attachedRigidbody.tag);
    }

    void Update()
    {
      
        if (Input.GetKeyDown(KeyCode.LeftArrow) && (Colision.flag == true))
        {
            transform.position += Vector3.up * jumpHeight;
            if (LeftCollision.isLeftAvailable)
                transform.position += Vector3.left * step;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && (Colision.flag == true))
        {
            transform.position += Vector3.up * jumpHeight;
            if (RightCollision.isRightAvailable)
                transform.position += Vector3.right * step;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && (Colision.flag == true))
        {
            transform.position += Vector3.up * jumpHeight;
            if (FrontCollision.isFrontAvailable)
                transform.position += Vector3.forward * step;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && (Colision.flag == true))
        {
            transform.position += Vector3.up * jumpHeight;
            if (BackCollision.isBackAvailable)
                transform.position += Vector3.back * step;
        }
    }
}