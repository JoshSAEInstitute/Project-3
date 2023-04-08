using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

public class AICompanion : MonoBehaviour
{

    public float speed = 3f;

    //Sight
    public float followRange = 10f;
    private Transform player;

    //Command
    private Transform command;
    public float nearCommand = 5f;

    public float nearPlayer = 3f;

    //Input System
    public InputManager pcs;
    private InputAction recall, scout;

    //Behaviour
    public enum behaviour { idle, approach, scout, recall, roam }
    public behaviour companionState;

    //Sensor
    public CompInventory inventory;
    //private Collider other;

    //Independent
    public bool collect = false;

    private void Awake()
    {
        pcs = new InputManager();
    }
    
    #region New Input System
    private void OnEnable()
    {
        //Detect Spacebar press
        recall = pcs.Player.Recall;
        recall.Enable();
        recall.performed += Recall;

        //Detect Spacebar press
        scout = pcs.Player.Scout;
        scout.Enable();
        scout.performed += Scout;
    }

    private void OnDisable()
    {
        recall.Disable();
        scout.Disable();
    }
    #endregion

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        command = GameObject.FindGameObjectWithTag("Destination").transform;
        //inventory = GameObject.FindGameObjectWithTag("Sensor").GetComponent<CompInventory>();
        inventory = GetComponent<CompInventory>();
    }

    private void Update()
    {
        float distanceFromPlayer = Vector3.Distance(player.position, transform.position);
        float distanceFromCommand = Vector3.Distance(command.position, transform.position);

        switch (companionState)
        {
            case behaviour.idle:

                //Debug.Log("I'm idle");
                FacePlayer();

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

                FaceCommand();
                transform.position = Vector3.MoveTowards(this.transform.position, command.position, speed * Time.deltaTime);

                //--- ROAM
                if(distanceFromCommand <= nearCommand)
                {
                    companionState = behaviour.roam;
                }

                break;

            case behaviour.roam:

                FacePlayer();
                //Debug.Log("I'm roaming");
                if(collect == true)
                {
                    
                    Debug.Log("Need to start collecting");
                }
                //inventory.OnTriggerEnter(other);

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

    #region Facing Something

    private void FacePlayer()
    {
        if (player != null)
        {
            transform.LookAt(player.position);
        }
    }

    private void FaceCommand()
    {
        if(command != null)
        {
            transform.LookAt(command.position);
        }
    }

    #endregion

    #region Input Commands

    private void Recall(InputAction.CallbackContext context)
    {
        //Debug.Log("This works");
        companionState = AICompanion.behaviour.recall;

    }

    private void Scout(InputAction.CallbackContext context)
    {
        //Debug.Log("This works");
        companionState = AICompanion.behaviour.scout;

    }

    #endregion


}
