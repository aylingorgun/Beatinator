using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Move : MonoBehaviour
{

    public float speed = 1.5f;
    public float step = 5f;

    void Update()
    {
      
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * speed * Time.deltaTime * step;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * speed * Time.deltaTime * step;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.position += Vector3.forward * speed * Time.deltaTime * step;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.position += Vector3.back * speed * Time.deltaTime * step;
        }

    }
}