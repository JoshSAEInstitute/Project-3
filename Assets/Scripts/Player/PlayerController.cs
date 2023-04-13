using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    private Rigidbody rb;

    [SerializeField] private float movingSpeed = 5f;
    //[SerializeField] private float rotationSpeed = 5f;
    public Vector2 dirMove;
    private Vector2 dirRotation;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnMove(InputValue value)
    {
        dirMove = value.Get<Vector2>();
        rb.velocity =  dirMove * movingSpeed;
    }

    private void Update()
    {
        updateModel();

        //Debug.Log("x: " + dirMove.x + " |y: " + dirMove.y);
    }

    private void updateModel()
    {
        if(rb.velocity.x > 0f)
        {

            transform.localEulerAngles = new Vector3(0, 90, -90);

        } else if (rb.velocity.x < 0f)
        {
            transform.localEulerAngles = new Vector3(0, -90, 90);
        }

        if(rb.velocity.y > 0f)
        {
            transform.localEulerAngles = new Vector3(-90, 0, 0);
        } else if(rb.velocity.y < 0f)
        {
            transform.localEulerAngles = new Vector3(90, 180, 0);
        }
    }

}
