using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ItemCollector : MonoBehaviour
{
    //Near
    //private float near = 3f;
    
    //Collectible Number
    //Raw
    public int ingredients = 0;

    //Refined
    public int food = 0;

    /*
    //Player and Companion Transform
    private Transform player;
    private Transform companion;
    */

    //Text
    public TMP_Text ingredientsText;
    public TMP_Text foodText;

    /*
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        companion = GameObject.FindGameObjectWithTag("Companion").transform;
    }
    */

    private void OnTriggerEnter(Collider other)
    {
        //When the player touches the collectible, the collectible count goes up and gets destroyed
        if (other.gameObject.CompareTag("Ingredient"))
        {
            //Debug.Log("Collect me");
            Destroy(other.gameObject);
            IncreaseIngredients(1);
        }
        else if(other.gameObject.CompareTag("Campfire"))
        {
            ingredientsText.text = "Ingredients: ".ToString() + ingredients.ToString();
            foodText.text = "Food: ".ToString() + food.ToString();
        }
    }

    public void IncreaseIngredients(int amount)
    {
        ingredients = ingredients + amount;
        ingredientsText.text = "Ingredients: ".ToString() + ingredients.ToString();
    }

}
