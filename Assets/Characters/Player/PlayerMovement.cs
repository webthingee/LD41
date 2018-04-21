using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : CharacterMovement 
{
    public bool doJump;
    public float latterDetection;

    protected override void Update () 
    {
        climbAxis = Input.GetAxisRaw("Vertical");
        moveDirection.x = Input.GetAxisRaw("Horizontal");
        moveDirection.x *= moveSpeed;
        MoveCharacter();
        base.Update();
	}

    public void Jump ()
    {
        if (jumpAvailable)
            doJump = true;
    }

    void MoveCharacter ()
    {
        /// Jump : Double Jump
        // if (canDoubleJump && Input.GetButtonDown("Jump"))
        // {
        //     if (canDoubleJump)
        //     {
        //         moveDirection.y = doubleJumpSpeed;
        //         canDoubleJump = false;
        //     }
        // }

        /// Wall Climb
        // if (Input.GetButton("Utility"))
        // {
        //     if (isRight || isLeft)
        //     {
        //         isClimbing = true;
        //     }
        // }
        // else
        // {
        //     isClimbing = false;
        // }

        /// Grounded
        if (isGrounded)
        {
            moveDirection.y = 0;
            isJumping = false;
            jumpAvailable = true;

            if (jumpAvailable && doJump) //Input.GetAxisRaw("Jump") != 0)
            {
                //moveDirection.y = 0;
                isClimbing = false;
                moveDirection.y = jumpSpeed;
                canDoubleJump = true;
                isJumping = true;
                jumpAvailable = false;
                doJump = false;
            }
            // if (Input.GetAxisRaw("Jump") == 0)
            // {
            //     jumpAvailable = true;
            // }
        }

        Debug.Log(LatterDetection());

        if (LatterDetection())
        {
            if  (climbAxis != 0)
            {
                isClimbing = true;
                moveDirection.y = climbAxis * climbSpeed;
            }
            else
            {
                moveDirection.y = 0;
            }
        }
        else
        {
            isClimbing = false;
        }

        /// Jump : Hold for full height
        // if (Input.GetButtonUp("Jump"))
        // {
        //     if (moveDirection.y > 0)
        //     {
        //         moveDirection.y = moveDirection.y * 0.5f;
        //     }
        // }
    }

    // private void WallClimbing()
    // {
    //     // @TODO: can still jump up during climb, not sure I like that
    //     moveDirection.x = 0;
        
    //     if (WallClimbNorth() || WallClimbSouth())
    //         moveDirection.y = climbAxis;
        
    //     if (!WallClimbNorth() && moveDirection.y >= 0)
    //         moveDirection.y = 0;

    //     if (!WallClimbSouth() && moveDirection.y <= 0)
    //         moveDirection.y = 0;

    //     moveDirection.y *= speed / 4f;

    //     if (Input.GetAxisRaw("Jump") != 0 && Input.GetAxis("Horizontal") != 0)
    //     {
    //         //moveDirection.y = 0;
    //         isClimbing = false;
    //         moveDirection.y = jumpSpeed;
    //         canDoubleJump = true;
    //         isJumping = true;
    //         jumpAvailable = false;
    //     }
    // }

    bool LatterDetection ()
    {
        var rayStart = transform.position;
        var rayDir = Vector2.down;
        float rayDist = latterDetection;

        Debug.DrawRay(rayStart, rayDir * rayDist, Color.green);

        return Physics2D.Raycast(rayStart, rayDir, rayDist, 1 << LayerMask.NameToLayer("Latter"));
    }

    // bool WallClimbSouth ()
    // {
    //     var rayStart = transform.position;
    //     rayStart.x -= 0.5f;
    //     rayStart.y -= 0.1f;
    //     var rayDir = Vector2.right;
    //     float rayDist = 1f;

    //     Debug.DrawRay(rayStart, rayDir * rayDist, Color.green);

    //     return Physics2D.Raycast(rayStart, rayDir, rayDist, 1 << LayerMask.NameToLayer("Walkable"));
    // }
}
