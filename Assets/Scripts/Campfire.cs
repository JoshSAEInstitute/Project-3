using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Campfire : MonoBehaviour
{

    [SerializeField] private int ingredientsAmount;

    private void OnTriggerStay(Collider other)
    {

        //This checks the amount of collectibles the player has as soon as they enter in range
        //It then converts it into refined materials

        if(other.gameObject.CompareTag("Player"))
        {
            //Debug.Log("You're in the campfire");
            if(other.GetComponent<ItemCollector>() != null)
            {
                ItemCollector collectible = other.GetComponent<ItemCollector>();
                if(collectible.ingredients >= ingredientsAmount)
                {
                    Debug.Log("You have collected lots ingredients");

                    //Decrease ingredients to make 1 food
                    collectible.IncreaseIngredients(-ingredientsAmount);
                    collectible.IncreaseFood(1);

                } else if(collectible.ingredients < ingredientsAmount)
                {
                    Debug.Log("Collect more ingredient");
                }
            }
        }
    }

}
