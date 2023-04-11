using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NearCompanion : MonoBehaviour
{

    //Timer before it gets destroyed
    public float waitTime = 5f;

    //Companion location
    private Transform companion;

    //Materials
    public Material[] material;
    Renderer rend;

    private float compSight = 10f;

    //Access player's Item collector
    private ItemCollector itemCollector;

    //Access to companion's inventory
    private CompInventory compInventory;
    private bool stored = false;

    private void Start()
    {
        //Manipulates how the object looks like
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[0];
        companion = GameObject.FindGameObjectWithTag("Companion").transform;

        //Gets the player's collector
        itemCollector = GameObject.FindGameObjectWithTag("Player").GetComponent<ItemCollector>();

        //Adds in the companion's inventory
        compInventory = GameObject.FindGameObjectWithTag("Companion").GetComponent<CompInventory>();
        //compInventory.ingredients.Add(this.transform);

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

        float distanceFromCompanion = Vector2.Distance(companion.position, transform.position);

        //Changes renderer colour depending on how close the companion is
        if(distanceFromCompanion <= compSight)
        {
            //Set material to 1
            rend.sharedMaterial = material[1];

            //Add this item's location to the companion's inventory
            if(stored == false)
            {
                compInventory.ingredients.Add(this.transform);
                stored = true;
            }

        } else
        {
            rend.sharedMaterial = material[0];

            //Removes from the inventory
            if(stored == true)
            {
                compInventory.ingredients.Remove(this.transform);
                stored = false;
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        //Companion collects item
        if(other.gameObject.CompareTag("Companion"))
        {
            compInventory.ingredients.Remove(this.transform);
            itemCollector.IncreaseIngredients(1);
            Destroy(gameObject);
        }
    }

}
