using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject itemToSpawn;
    public int numSpawns = 1;

    private float nextSpawn;
    public float spawnRate = 1;

    /*
    public float itemX = 20f;
    public float itemY = 20f;
    */

    public float radius = 50f;

    private void Update()
    {
        //Spawn rate depends on spawning radius
        spawnRate = radius / 1000;

        if(nextSpawn < Time.time)
        {
            SpawnItem();
            nextSpawn = Time.time + spawnRate;
        }
    }

    private void SpawnItem()
    {
        //Place where to spawn the items
        Vector2 targetRandomPosition = Random.onUnitSphere * radius;

        //Vector2 randomPos = new Vector2(Random.Range(-itemX, itemX), Random.Range(-itemY, itemY));
        GameObject clone = Instantiate(itemToSpawn, targetRandomPosition, itemToSpawn.transform.rotation);
    }

    /*
    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0,0,1,0.3f);
        Gizmos.DrawCube(transform.position, new Vector2((itemX + -itemX)/2, (itemY + -itemY)/2));
    }
    */
    

}
