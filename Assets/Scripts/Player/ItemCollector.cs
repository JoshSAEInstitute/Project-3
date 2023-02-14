using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ItemCollector : MonoBehaviour
{
    //Collectible Number
    //Raw
    public int scraps = 0;
    public int ingredients = 0;

    //Refined
    public int wood = 0;
    public int food = 0;

    //Text
    [SerializeField] private TMP_Text scrapsText;
    [SerializeField] private TMP_Text ingredientsText;
    [SerializeField] private TMP_Text woodText;
    [SerializeField] private TMP_Text foodText;


    private void OnTriggerEnter(Collider other)
    {
        //When the player touches the collectible, the collectible count goes up and gets destroyed
        if(other.gameObject.CompareTag("Scraps"))
        {
            //Debug.Log("Collect me");
            Destroy(other.gameObject);
            scraps++;
            scrapsText.text = "Scraps: ".ToString() + scraps.ToString();
        }
        else if (other.gameObject.CompareTag("Ingredient"))
        {
            //Debug.Log("Collect me");
            Destroy(other.gameObject);
            ingredients++;
            ingredientsText.text = "Ingredients: ".ToString() + ingredients.ToString();
        }
        else if(other.gameObject.CompareTag("Campfire"))
        {
            scrapsText.text = "Scraps: ".ToString() + scraps.ToString();
            woodText.text = "Wood: ".ToString() + wood.ToString();
            ingredientsText.text = "Ingredients: ".ToString() + ingredients.ToString();
            foodText.text = "Food: ".ToString() + food.ToString();
        }
    }

}
