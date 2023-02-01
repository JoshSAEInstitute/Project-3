using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    public float speed;
    private Vector2 move;

    public void Move(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movePlayer();
    }

    public void movePlayer()
    {
        //Where the player will move
        Vector3 movement = new Vector3(move.x, 0f, move.y);

        //Player rotation
        //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15f);

        //Player move towards that point
        transform.Translate(movement * speed * Time.deltaTime, Space.World);
    }
}
