using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using TMPro;

public class Move : MonoBehaviour
{
    //Step size
    public float step = 2f;
    public float jumpHeight = 0.35f;
    public TextMeshProUGUI faultNumber;

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
            transform.position += Vector3.up * jumpHeight;
            if (LeftCollision.isLeftAvailable)
                transform.position += Vector3.left * step;
            else
                Mistake();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position += Vector3.up * jumpHeight;
            if (RightCollision.isRightAvailable)
                transform.position += Vector3.right * step;
            else
                Mistake();
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.position += Vector3.up * jumpHeight;
            if (FrontCollision.isFrontAvailable)
                transform.position += Vector3.forward * step;
            else
                Mistake();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.position += Vector3.up * jumpHeight;
            if (BackCollision.isBackAvailable)
                transform.position += Vector3.back * step;
            else
                Mistake();
        }
    }

    private void Mistake()
    {   
        //TODO: Implement fault tracking class
        faultNumber.text = (++fault).ToString();
    }
}