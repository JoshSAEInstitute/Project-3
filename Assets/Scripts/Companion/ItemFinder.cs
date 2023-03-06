using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ItemFinder : MonoBehaviour
{

    public float detectRadius = 10f;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Collectible")
        {
            Debug.Log("Item Found!");


        }
    }


}
