using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    private Rigidbody rb;

    [SerializeField] private float movingSpeed = 5f;
    [SerializeField] private float rotationSpeed = 5f;
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

        updateModel();
    }

    private void updateModel()
    {
        if(dirMove.x > 0f)
        {

            transform.localEulerAngles = new Vector2(dirRotation.x, 90);

        } else if (dirMove.x < 0f)
        {
            transform.localEulerAngles = new Vector2(dirRotation.x, -90);
        }

        if(dirMove.y > 0f)
        {
            transform.localEulerAngles = new Vector2(dirRotation.x, dirRotation.y);
        } else if(dirMove.y < 0f)
        {
            transform.localEulerAngles = new Vector2(dirRotation.x, dirRotation.y);
        }
    }

}
