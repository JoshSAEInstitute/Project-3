using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NearCompanion : MonoBehaviour
{

    private Transform companion;

    public Material[] material;
    Renderer rend;

    private float compSight = 10f;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[0];
        companion = GameObject.FindGameObjectWithTag("Companion").transform;

    }

    private void Update()
    {
        float distanceFromCompanion = Vector3.Distance(companion.position, transform.position);

        if(distanceFromCompanion <= compSight)
        {
            rend.sharedMaterial = material[1]; 
        } else
        {
            rend.sharedMaterial = material[0];
        }
    }

}
