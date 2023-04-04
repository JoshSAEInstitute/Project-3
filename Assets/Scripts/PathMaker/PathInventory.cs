using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathInventory : MonoBehaviour
{
    //Storing each path with a directional opening
    public GameObject[] upperPath;
    public GameObject[] rightPath;
    public GameObject[] bottomPath;
    public GameObject[] leftPath;

    public GameObject closedPath;

    public List<GameObject> paths;

    //Spawn last path
    [SerializeField] private float waitTime;
    private bool spawnedEndPath;
    public GameObject endPath;

    private void Update()
    {
        //Check if all paths have been spawned first
        if(waitTime <= 0 && spawnedEndPath == false)
        {
            for (int i = 0; i < paths.Count; i++)
            {
                if(i == paths.Count - 1)
                {
                    Instantiate(endPath, paths[i].transform.position, Quaternion.identity);
                    spawnedEndPath = true;
                }
            }
        } else
        {
            waitTime -= Time.deltaTime;
        }
    }

}
