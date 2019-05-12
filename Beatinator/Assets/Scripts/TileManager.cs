using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    //This array contains the tiles we will use.
    //Add those tiles in the editor screen.
    public GameObject[] tilePrefabs;

    // This is player's transform values
    private Transform playerTransform;
    // This is inital tiles starting point it exists because 
    //if we don't have this first tile will be created above us.
    private float spawnZ = 0f;
    //Our tiles length we have this because we will calculate 
    //where should we create the next tile.
    private float tileLength = 30f;   
    //This is the value of when we should delete the previous tile.
    private float safeZone = 40.0f;         
    //How many tiles should be on the screen. For mobile dev keep it low.
    private int amnTilesOnScreen = 5;
    //This is a kind of flag for not to create same tile twice. 
    private int lastPrefabIndex = 0;
    //We have a list to store amntofTiles for keeping track of deleting.
    private List<GameObject> activeTiles;

    private GenerateHolesandWalls haw;

    private void Start()
    {
        
        activeTiles = new List<GameObject>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        for (int i=0; i< amnTilesOnScreen; i ++)
        {
            if (i < 2)//First two are kind of default tiles for test.
                SpawnTile(0);
            else //Then randomize
                SpawnTile();
        }
    }
    
    private void Update()
    {
        if(playerTransform.position.z - safeZone > (spawnZ - amnTilesOnScreen * tileLength))
        {
            SpawnTile();
            DeleteTile();
        }
    }

    private void SpawnTile(int prefabIndex = -1)
    {
        GameObject go;
        if (prefabIndex == -1)
        {
            go = Instantiate(tilePrefabs[RandomPrefabIndex()]) as GameObject;
        }
        else
        {
            if (prefabIndex == 0)
            {
                haw = FindObjectOfType<GenerateHolesandWalls>();
                Destroy(haw);
            }
            go = Instantiate(tilePrefabs[prefabIndex]) as GameObject;
        }

        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spawnZ;
        spawnZ += tileLength;
        activeTiles.Add(go);
    }

    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }

    private int RandomPrefabIndex()
    {
        if (tilePrefabs.Length <= 1)
            return 0;

        int randomIndex = lastPrefabIndex;
        while(randomIndex == lastPrefabIndex)
        {
            randomIndex = Random.Range(0, tilePrefabs.Length);
        }
        lastPrefabIndex = randomIndex;
        return randomIndex;
    }
}
