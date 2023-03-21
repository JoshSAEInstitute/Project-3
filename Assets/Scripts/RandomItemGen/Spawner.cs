using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject itemToSpawn;
    public int numSpawns = 1;

    private float nextSpawn;
    public float spawnRate = 1;

    public float itemX = 2f;
    public float itemY = 2f;
    public float itemZ = 2f;

    private void Update()
    {
        if(nextSpawn < Time.time)
        {
            SpawnItem();
            nextSpawn = Time.time + spawnRate;
        }
    }

    private void SpawnItem()
    {
        //Place where to spawn the items
        Vector3 randomPos = new Vector3(Random.Range(-itemX, itemX), itemY / 2, Random.Range(-itemZ, itemZ));
        GameObject clone = Instantiate(itemToSpawn, randomPos, Quaternion.identity);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0,0,1,0.3f);
        Gizmos.DrawCube(transform.position, new Vector3(itemX, itemY, itemZ));
    }

}
