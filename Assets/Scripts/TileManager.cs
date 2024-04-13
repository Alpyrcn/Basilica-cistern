using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    // Create a new empty game object
    public GameObject[] tilePrefabs;
    public float zSpawn = 0;
    public float tileLength = 8; //units 
    public int numberOftiles = 5;

    private List<GameObject> activeTiles = new List<GameObject>();

    public Transform playerTransform;
    void Start()
    {
        for(int i = 0; i < numberOftiles; i++)
        {
            if (i == 0)
                SpawnTile(0);
            else
                SpawnTile(Random.Range(1, tilePrefabs.Length));
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Delete tiles 
        if(playerTransform.position.z -8 > zSpawn - (numberOftiles * tileLength)) // playerTransform.position.z - units/2(scale)
        {
            SpawnTile(Random.Range(0, tilePrefabs.Length));
            DeleteTile();
        }
    }
    public void SpawnTile(int tileIndex)
    {
        GameObject go = Instantiate(tilePrefabs[tileIndex], transform.forward * zSpawn, transform.rotation);
        activeTiles.Add(go);
        zSpawn += tileLength;
    }

    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
}
