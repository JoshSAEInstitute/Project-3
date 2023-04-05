using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompAdd : MonoBehaviour
{
    //Add to list
    private CompInventory compInventory;

    private void Start()
    {
        compInventory = GameObject.FindGameObjectWithTag("Sensor").GetComponent<CompInventory>();
        compInventory.ingredients.Add(this.gameObject);
    }

}
