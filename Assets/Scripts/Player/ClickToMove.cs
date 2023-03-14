using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

public class ClickToMove : MonoBehaviour
{
    //Input Sytem
    [SerializeField] private InputAction mouseClickAction;

    //Commands
    public InputManager pcs;
    private InputAction recall;

    //Speed
    public float playerSpeed = 10;
    public float rotationSpeed = 3;

    private Camera mainCamera;
    private Coroutine coroutine;
    private Vector3 targetPosition;

    private Rigidbody rb;
    private AICompanion aiComp;

    private void Awake()
    {
        pcs = new InputManager();
        mainCamera = Camera.main;
        rb = GetComponent<Rigidbody>();
        aiComp = GetComponent<AICompanion>();
    }

    private void OnEnable()
    {
        //Detect Spacebar press
        recall = pcs.Player.Recall;
        recall.Enable();
        recall.performed += Recall;

        //Detect pressed mouse
        mouseClickAction.Enable();
        //Use this so that when not used we can unsubscribe for this easily
        mouseClickAction.performed += Move;
    }

    private void OnDisable()
    {
        recall.Disable();

        mouseClickAction.performed -= Move;
        mouseClickAction.Disable();
    }

    private void Move(InputAction.CallbackContext context)
    {
        //Where do we need to move towards.
        //Converting screen coordinates into game coordinates.
        Ray ray = mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
        if(Physics.Raycast(ray: ray, hitInfo: out RaycastHit hit) && hit.collider)
        {
            //Checks if there is a current coroutine running, if there is one this will not run until
            //Previous coroutine is finished
            if (coroutine != null) StopCoroutine(coroutine);
            coroutine = StartCoroutine(PlayerMoveTowards(hit.point));

            //Gizmos
            targetPosition = hit.point;
        }
    }

    private void Recall(InputAction.CallbackContext context)
    {
        Debug.Log("This works");
        //aiComp.companionState = AICompanion.behaviour.recall;

    }

    private IEnumerator PlayerMoveTowards(Vector3 target)
    {
        //Makes the target be equal to eye level
        float playerDistanceToFloor = transform.position.y - target.y;
        target.y += playerDistanceToFloor;
        while(Vector3.Distance(transform.position, target) > 1.5f)
        {

            Vector3 destination = Vector3.MoveTowards(transform.position, target, playerSpeed * Time.deltaTime);
            //transform.position = destination;

            Vector3 direction = target - transform.position;
            Vector3 movement = direction.normalized * playerSpeed * Time.deltaTime;


            rb.velocity = direction.normalized * playerSpeed;



            //Rotation
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction.normalized), rotationSpeed * Time.deltaTime);

            //To not make the while loop go crazy
            yield return null;


        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(targetPosition, 1);
    }


}
