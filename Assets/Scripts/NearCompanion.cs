using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NearCompanion : MonoBehaviour
{

    private Transform companion;

    //Materials
    public Material[] material;
    Renderer rend;

    private float compSight = 10f;

    //Access player's Item collector
    private ItemCollector itemCollector;

    private void Start()
    {
        //Manipulates how the object looks like
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[0];
        companion = GameObject.FindGameObjectWithTag("Companion").transform;

        itemCollector = GameObject.FindGameObjectWithTag("Player").GetComponent<ItemCollector>();

    }


    private void Update()
    {
        float distanceFromCompanion = Vector3.Distance(companion.position, transform.position);

        //Changes renderer colour depending on how close the companion is
        if(distanceFromCompanion <= compSight)
        {
            rend.sharedMaterial = material[1]; 
        } else
        {
            rend.sharedMaterial = material[0];
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Companion"))
        {
            itemCollector.IncreaseIngredients(1);
            Destroy(gameObject);
        }
    }

}
