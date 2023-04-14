using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaPlayer : MonoBehaviour
{
    //Sets the stamina of the player
    public int maxStamina = 100;
    public int currentStamina;

    public StaminaBar staminaBar;

    //HUNGER
    //How long before the player gets hungry
    [SerializeField] private float hungerCD = 3;
    private float waitTime;

    //Checks food
    private ItemCollector food;

    private void Start()
    {
        food = GameObject.FindGameObjectWithTag("Player").GetComponent<ItemCollector>();
        currentStamina = maxStamina;
        staminaBar.SetMaxStamina(maxStamina);
        waitTime = hungerCD;
    }

    private void Update()
    {

        if(currentStamina <= 1 && food.food > 0)
        {
            //Use food to replenish hunger bar
            food.food--;
            food.foodText.text = "Food: ".ToString() + food.food.ToString();
            //Update hunger Bar
            currentStamina = maxStamina;
            staminaBar.SetStamina(currentStamina);
        }

        if(waitTime <= 0)
        {
            //As time passes, the player will get more and more hungry
            Starving(1);
            waitTime = hungerCD;
        } else
        {
            waitTime -= Time.deltaTime;
        }
    }

    void Starving(int starving)
    {
        //When starving, removes the amount in the Stamina bar
        currentStamina -= starving;

        //Update stamina GUI
        staminaBar.SetStamina(currentStamina);
    }

}
