using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveForce, maxSpeed, jumpForce;
    
    private float moveDir; 
    private Rigidbody2D myRB;

    private void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        var moveAxis = Vector2.right * moveDir;

        if(Mathf.Abs(myRB.velocity.x) < maxSpeed)
        {
            myRB.AddForce(moveAxis * moveForce, ForceMode2D.Force);
        }
        
    }

    public void Move(InputAction.CallbackContext context)
    {
        moveDir = context.ReadValue<float>();
    }

    public void Jump(InputAction.CallbackContext context)
    {
        myRB.AddForce(Vector2.up* jumpForce, ForceMode2D.Impulse);
    }
}
