using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICompanion : MonoBehaviour
{

    public float speed;

    //Sight
    public float followRange;
    private Transform player;
    private Transform command;

    public float nearPlayer;

    //Behaviour
    public enum behaviour { idle, approach, scout, recall, roam }
    public behaviour companionState;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        command = GameObject.FindGameObjectWithTag("Destination").transform;
    }

    private void Update()
    {
        float distanceFromPlayer = Vector3.Distance(player.position, transform.position);

        switch (companionState)
        {
            case behaviour.idle:

                //Debug.Log("I'm idle");

                //--- APPROACH
                if (distanceFromPlayer >= followRange)
                {
                    companionState = behaviour.approach;
                }

                break;

            case behaviour.approach:

                //Debug.Log("I'm approaching");

                //As the name says, to look at the player
                FacePlayer();

                //Companion approaches player
                transform.position = Vector3.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);

                //--- IDLE
                if (distanceFromPlayer <= nearPlayer)
                {
                    companionState = behaviour.idle;
                }

                break;

            case behaviour.recall:

                //Debug.Log("I've been recalled!");

                //--- APPROACH
                companionState = behaviour.approach;

                break;

            case behaviour.scout:

                transform.position = Vector3.MoveTowards(this.transform.position, command.position, speed * Time.deltaTime);

                //--- ROAM
                if(this.transform.position == command.position)
                {
                    companionState = behaviour.scout;
                }

                break;

            case behaviour.roam:

                //Debug.Log("I'm roaming");

                break;

            default:
                companionState = behaviour.idle;
                break;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, followRange);
        Gizmos.DrawWireSphere(transform.position, nearPlayer);
    }

    private void FacePlayer()
    {
        if (player != null)
        {
            transform.LookAt(player.position);
        }
    }

}
