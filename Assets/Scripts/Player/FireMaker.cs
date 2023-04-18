using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FireMaker : MonoBehaviour
{
    //Get warning
    [SerializeField] private GameObject warning;

    private float waitTime;
    private float initialWait = 2;

    //To check items within the player's inventory
    private ItemCollector foodAmount;

    //Where to instantiate the campfire
    [SerializeField] private GameObject firePlace;
    private Transform command;

    //Food needed to create one
    [SerializeField] private int buildReq;

    private void Start()
    {
        command = GameObject.FindGameObjectWithTag("Destination").transform;
        foodAmount = GameObject.FindGameObjectWithTag("Player").GetComponent<ItemCollector>();
        waitTime = initialWait;
    }

    void OnFireMaker(InputValue value)
    {
        Debug.Log("Making Bonfires");

        if(foodAmount.food >= buildReq)
        {
            //Create the fire place at the command's location
            warning.SetActive(false);
            Instantiate(firePlace, new Vector3(command.transform.position.x, command.transform.position.y, 1f), firePlace.transform.rotation);
            foodAmount.IncreaseFood(-buildReq);
        } else if(foodAmount.food < buildReq)
        {
            warning.SetActive(true);
        }

    }


}
