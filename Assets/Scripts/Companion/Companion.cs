using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Companion : MonoBehaviour
{

    public float speed;

    //Sight
    public float followRange;
    private Transform player;

    //Behaviour
    public enum behaviour { idle, approach}
    public behaviour companionState;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        float distanceFromPlayer = Vector3.Distance(player.position, transform.position);

        switch (companionState)
        {
            case behaviour.idle:

                Debug.Log("I'm idle");

                //--- APPROACH
                if( distanceFromPlayer >= followRange)
                {
                    companionState = behaviour.approach;
                }

                break;


            case behaviour.approach:

                Debug.Log("Don't leave me!");

                //Companion approaches player
                transform.position = Vector3.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);

                //--- IDLE
                if(distanceFromPlayer <= followRange)
                {
                    companionState= behaviour.idle;
                }

                break;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, followRange);
    }

}
