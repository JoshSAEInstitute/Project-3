using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddPath : MonoBehaviour
{

    private PathInventory inventory;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Paths").GetComponent<PathInventory>();
        inventory.paths.Add(this.gameObject);
    }

}
