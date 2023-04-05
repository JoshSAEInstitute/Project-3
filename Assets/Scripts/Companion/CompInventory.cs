using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompInventory : MonoBehaviour
{

    public List<GameObject> ingredients;
    public Vector3 ingredientLocation;

    public AICompanion companion;

    private void Start()
    {
        companion= GameObject.FindGameObjectWithTag("Companion").GetComponent<AICompanion>();
    }

    public void OnTriggerStay(Collider other)
    {
        //Debug.Log("Pre Collided");
        if((ingredients.Contains(other.gameObject)) && (companion.companionState == AICompanion.behaviour.roam))
        {
            //Vector3 ingredientLocation = other.GameObject.GetComponent<Transform>().transform;
            companion.collect = true;
            //Debug.Log("I've being sensed!");
        }
    }

}
