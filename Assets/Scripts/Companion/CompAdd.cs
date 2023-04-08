using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompAdd : MonoBehaviour
{
    //Calls the list where it will be stored
    private CompInventory compInventory;

    public float waitTime = 5f;

    private void Start()
    {
        compInventory = GameObject.FindGameObjectWithTag("Companion").GetComponent<CompInventory>();
        compInventory.ingredients.Add(this.transform);
    }

    private void Update()
    {
        //Destroys this object after a set amount of time and it removes it from the ingredients list
        if (waitTime <= 0)
        {
            compInventory.ingredients.Remove(this.transform);
            Destroy(gameObject);
        }
        else
        {
            waitTime -= Time.deltaTime;
        }
    }

}
