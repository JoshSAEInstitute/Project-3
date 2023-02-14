using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Campfire : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {

        //This checks the amount of collectibles the player has as soon as they enter in range
        //It then converts it into refined materials

        if(other.gameObject.CompareTag("Player"))
        {
            //Debug.Log("You're in the campfire");
            if(other.GetComponent<ItemCollector>() != null)
            {
                ItemCollector collectible = other.GetComponent<ItemCollector>();
                if(collectible.ingredients >= 3)
                {
                    Debug.Log("You have collected lots ingredients");

                    collectible.ingredients = collectible.ingredients - 3;
                    collectible.food++;

                } else if(collectible.ingredients < 3)
                {
                    Debug.Log("Collect more ingredient");
                }
            }
        }
    }

}
