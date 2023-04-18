using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Escape : MonoBehaviour
{

    private Spawner spawner;

    private Transform player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        spawner = GameObject.FindGameObjectWithTag("ItemSpawner").GetComponent<Spawner>();
    }

    private void OnEnable()
    {
        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);
        spawner.radius = distanceFromPlayer + 50f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            SceneManager.LoadScene("Victory");
        }
    }
}
