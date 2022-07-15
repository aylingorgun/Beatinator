using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaserFollow : MonoBehaviour
{
    private GameObject chaser;
    private GameObject player;
    private float step = 2;
    private float followDistance = 16f;
    // Start is called before the first frame update
    void Start()
    {
        chaser = GameObject.FindGameObjectWithTag("Chaser");
        player = GameObject.FindGameObjectWithTag("Player");
    }

    //booleans represent where the getcloser method is called from
    public void GetCloser()
    {
            chaser.transform.position += Vector3.forward * step;
    }
    

    public void CheckIfLeftBehind()
    {
        if (transform.position.z + followDistance < player.transform.position.z)
            GetCloser();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            FindObjectOfType<Move>().Death();
        else
            Destroy(other.gameObject);
    }
}
