using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

public class AICompanion : MonoBehaviour
{

    private float speed;
    [SerializeField] private float initialSpeed = 5f;
    [SerializeField] private float dashingSpeed = 8f;

    //Sight
    public float followRange = 10f;
    private Transform player;
    [SerializeField] private float wayTooFar = 20f;

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

    //Companion Inventory
    public CompInventory inventory;
    private int rand;
    private Transform lockOnLocation;
    private float waitTime;
    [SerializeField]private float initialWaitTime = 5f;
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

        speed = initialSpeed;
        waitTime = initialWaitTime;
    }

    private void Update()
    {
        //Ignores collision with the player
        //!!!Note to self, for some reason this doesn't work!!!!
        Physics.IgnoreCollision(this.GetComponent<Collider>(), GameObject.FindGameObjectWithTag("Player").GetComponent<Collider>(), true);

        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);
        float distanceFromCommand = Vector2.Distance(command.position, transform.position);

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
                    speed = initialSpeed;
                    companionState = behaviour.idle;
                }

                break;

            case behaviour.recall:

                //Debug.Log("I've been recalled!");
                speed = dashingSpeed;

                //--- APPROACH
                companionState = behaviour.approach;

                break;

            case behaviour.scout:

                FaceCommand();
                speed = dashingSpeed;
                transform.position = Vector3.MoveTowards(this.transform.position, command.position, speed * Time.deltaTime);

                //--- ROAM
                if(distanceFromCommand <= nearCommand)
                {
                    speed = initialSpeed;
                    companionState = behaviour.roam;
                }

                break;

            case behaviour.roam:


                //Gathers ingredients next to it
                if(inventory.ingredients.Count > 0 )
                {
                    //Selects random value to lock on to
                    if (waitTime <= 0)
                    {
                        rand = Random.Range(0, inventory.ingredients.Count);
                        waitTime = initialWaitTime;
                    } else
                    {
                        waitTime -= Time.deltaTime;
                    }
                    lockOnLocation = inventory.ingredients[rand];
                }

                //Moves towards the locked on item
                if (lockOnLocation != null)
                {
                    transform.LookAt(lockOnLocation.position);
                    transform.position = Vector3.MoveTowards(this.transform.position, lockOnLocation.position, speed * Time.deltaTime);
                }


                //--- RECALL
                if (distanceFromPlayer >= wayTooFar)
                {
                    companionState = behaviour.recall;
                }

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
        Gizmos.DrawWireSphere(transform.position, wayTooFar);

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
