using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideEnemy : MonoBehaviour
{
    public GameObject SideSpawn;
    public GameObject spawner;

    GameObject go;

    public float step = 2f;

    public void SpawnObject()
    {
        go = Instantiate(SideSpawn, new Vector3(spawner.transform.position.x, 0.15f, spawner.transform.position.z), Quaternion.Euler(90, 0, 0));
    }

    private void Update()
    {
        //go.transform.position += Vector3.right * step;
    }
}
