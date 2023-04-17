using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Escape : MonoBehaviour
{
    private Spawner spawner;

    private void Awake()
    {
        spawner = GameObject.FindGameObjectWithTag("ItemSpawner").GetComponent<Spawner>();
    }

    private void OnEnable()
    {
        spawner.itemX = this.transform.position.x;
        spawner.itemY= this.transform.position.y;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            SceneManager.LoadScene("Victory");
        }
    }
}
