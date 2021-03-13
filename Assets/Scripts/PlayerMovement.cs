using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveForce, maxSpeed, jumpForce;
    [SerializeField] private Collider2D groundCheck;
    [SerializeField] private LayerMask groundLayers;

    private float moveDir; 
    private Rigidbody2D myRB;
    private bool canJump;

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
       
        if(groundCheck.IsTouchingLayers(groundLayers))
        {
            canJump = true;
        }
        else
        {
            canJump = false;
        }
        if(moveDir == 0)
        {
            myRB.velocity = new Vector2(x: 0f, y: myRB.velocity.y);
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        moveDir = context.ReadValue<float>();
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (canJump)
        {
            myRB.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            canJump = false;
        }
       
    }
}
