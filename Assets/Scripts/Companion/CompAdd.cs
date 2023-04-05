using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompAdd : MonoBehaviour
{

    private CompInventory compInventory;

    private void Start()
    {
        compInventory = GameObject.FindGameObjectWithTag("Sensor").GetComponent<CompInventory>();
        compInventory.ingredients.Add(this.gameObject);
    }

}
