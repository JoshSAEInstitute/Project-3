using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomSpawner : MonoBehaviour
{

    public int pathDirection;
    // 1 = needs BOTTOM path
    // 2 = needs LEFT path
    // 3 = needs UPPER path
    // 4 = needs RIGHT path

    private PathInventory inventory;
    private int rand;
    public bool spawned = false;

    public float waitTime = 4f;

    private void Awake() 
    { 
        inventory = GameObject.FindGameObjectWithTag("Paths").GetComponent<PathInventory>(); 
    }

    private void Start()
    {
        //Destroys the spawner after a certain amount of time to reduce clatter.
        Destroy(gameObject, waitTime);

        // Call a function using invoke after a delay
        Invoke("Spawn", 0.1f);
    }

    private void Spawn()
    {
        if(spawned == false)
        {
            if (pathDirection == 1)
            {
                // Spawn room with a BOTTOM path

                //Choose a random value in the bottomPath array
                rand = Random.Range(0, inventory.bottomPath.Length);
                //Which is then instantiated at the spawner location with no rotation
                Instantiate(inventory.bottomPath[rand], transform.position, Quaternion.identity);
            }
            else if (pathDirection == 2)
            {
                // Spawn room with a LEFT path
                rand = Random.Range(0, inventory.leftPath.Length);
                Instantiate(inventory.leftPath[rand], transform.position, Quaternion.identity);
            }
            else if (pathDirection == 3)
            {
                // Spawn room with an UPPER path
                rand = Random.Range(0, inventory.upperPath.Length);
                Instantiate(inventory.upperPath[rand], transform.position, Quaternion.identity);
            }
            else if (pathDirection == 4)
            {
                // Spawn room with a RIGHT path
                rand = Random.Range(0, inventory.rightPath.Length);
                Instantiate(inventory.rightPath[rand], transform.position, Quaternion.identity);
            }
            spawned = true;
        }
 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Spawner"))
        {
            Debug.Log("Check if has spawner: " + other);
            if (other.GetComponent<RoomSpawner>().spawned == false && spawned == false)
            {
                Instantiate(inventory.closedPath, transform.position, Quaternion.identity);
                Debug.Log("Check if both are false: " + other);
            }
            spawned= true;
        }
        else
        {
            //Debug.Log("I have collided with: " + other);
        }
    }

}
