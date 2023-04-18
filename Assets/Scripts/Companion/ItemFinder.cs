
using UnityEngine;

public class ItemFinder : MonoBehaviour
{

    public float detectRadius = 10f;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Collectible")
        {
            Debug.Log("Item Found!");


        }
    }


}
