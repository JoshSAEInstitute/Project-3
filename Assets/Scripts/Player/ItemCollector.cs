using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ItemCollector : MonoBehaviour
{
    //Collectible Number
    private int collectible = 0;

    //Text
    [SerializeField] private TMP_Text collectibleText;

    private void OnTriggerEnter(Collider other)
    {
        //When the player touches the collectible, the collectible count goes up and gets destroyed
        if(other.gameObject.CompareTag("Collectible"))
        {
            Debug.Log("Collect me");
            Destroy(other.gameObject);
            collectible++;
            collectibleText.text = "Collectible: ".ToString() + collectible.ToString();
        }
    }

}
