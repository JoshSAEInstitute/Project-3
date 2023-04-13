using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FireMaker : MonoBehaviour
{

    private Transform command;

    [SerializeField] private GameObject firePlace;

    private void Start()
    {
        command = GameObject.FindGameObjectWithTag("Destination").transform;
    }

    void OnFireMaker(InputValue value)
    {
        Debug.Log("Making Bonfires");

        Instantiate(firePlace, command.transform.position, Quaternion.identity);
    }

}
