using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class Move : MonoBehaviour
{
    
    public float step = 2f;
    public float jumpHeight = 0.35f;
    private int faultCount = 0;
    public TextMeshProUGUI faultNumber;

    public GameObject RetryUI;

    public BoxCollider player;

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Has collided with " + other.attachedRigidbody.tag);
        if(other.gameObject.tag == "Hole")
        {
            player.enabled = false;
            RetryUI.SetActive(true);
        }
    }

    void Update()
    {
      
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position += Vector3.up * jumpHeight;
            if (LeftCollision.isLeftAvailable && CircleColision.TryMoving())
                transform.position += Vector3.left * step;
            else
                Mistake();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position += Vector3.up * jumpHeight;
            if (RightCollision.isRightAvailable && CircleColision.TryMoving())
                transform.position += Vector3.right * step;
            else
                Mistake();
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.position += Vector3.up * jumpHeight;
            if (FrontCollision.isFrontAvailable && CircleColision.TryMoving())
                transform.position += Vector3.forward * step;
            else
                Mistake();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.position += Vector3.up * jumpHeight;
            if (BackCollision.isBackAvailable && CircleColision.TryMoving())
                transform.position += Vector3.back * step;
            else
                Mistake();
        }
    }

    //May also implement mistake but move anyways
    private void Mistake()
    {
        faultNumber.SetText((++faultCount).ToString());
    }
}