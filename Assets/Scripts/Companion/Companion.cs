using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Companion : MonoBehaviour
{

    public float speed;

    //Sight
    public float followRange;
    private Transform player;

    public float nearPlayer;

    //Player position
    public Vector3 playerPrevPos;
    //private bool moving = false;

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

                //As the name sais, to look at the player
                FacePlayer();


                //Companion approaches player
                transform.position = Vector3.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);


                //Check if player is moving
                //IsPlayerMoving();

                //--- IDLE
                if(distanceFromPlayer <= nearPlayer)
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
        Gizmos.DrawWireSphere(transform.position, nearPlayer);
    }

    private void FacePlayer()
    {
        if(player != null)
        {
            transform.LookAt(player.position);
        }
    }

    private void IsPlayerMoving()
    {
        //Check the Player's previous position is different from its current position.
        var isMoving = playerPrevPos != player.position;

        if(isMoving)
        {
            //moving = true;
            //Companion approaches player
            transform.position = Vector3.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);
            return;

        }


        playerPrevPos = player.position;
        //moving = false;



    }

}
