using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RoboRyanTron.Unite2017.Events;

public class PlayerMovement : CharacterMovement 
{
    public bool doJump;
    public bool doDash = false;
    public float dashDistance = 3f;
    public AudioEvent dashSound;
    public GameObject dashDisplay;
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

    public void Dash ()
    {
        // if (dashAvailable)
            doDash = true;
    }

    void MoveCharacter ()
    {
        /// Grounded
        if (isGrounded)
        {
            moveDirection.y = 0;
            isJumping = false;
            jumpAvailable = true;

            if (jumpAvailable && Input.GetAxisRaw("Jump") != 0) //doJump) //
            {
                //moveDirection.y = 0;
                isClimbing = false;
                moveDirection.y = jumpSpeed;
                canDoubleJump = true;
                isJumping = true;
                jumpAvailable = false;
                doJump = false;
            }

            if (doDash)
            {
                DoTheDash();
                doDash = false;
            }
        }

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

    }

    bool LatterDetection ()
    {
        var rayStart = transform.position;
        var rayDir = Vector2.down;
        float rayDist = latterDetection;

        Debug.DrawRay(rayStart, rayDir * rayDist, Color.green);

        return Physics2D.Raycast(rayStart, rayDir, rayDist, 1 << LayerMask.NameToLayer("Latter"));
    }

    void DoTheDash ()
    {
        doDash = false;
        Vector3 _dirFacing = GetComponentInChildren<FiringCtrl>().transform.right;

        var rayStart = transform.position;
        var rayDir = _dirFacing;
        float rayDist = dashDistance;

        Debug.DrawRay(rayStart, rayDir * rayDist, Color.green);

        RaycastHit2D[] hits = Physics2D.RaycastAll(rayStart, rayDir, rayDist, 1 << LayerMask.NameToLayer("Obstacle"));

        if (hits != null)
        {
            Debug.Log("Hits");
            foreach(RaycastHit2D hit in hits)
            {
                Debug.Log(hit.collider.name);

                Component damageableComponent = hit.collider.gameObject.GetComponent(typeof(IDamageable)); // nullable value

			    if (damageableComponent)
			    {
				    (damageableComponent as IDamageable).TakeDamage(10);
			    }
		    }
        }
        Instantiate(dashDisplay, transform.position, transform.transform.rotation);
        dashSound.Play(SoundManager.Instance.GetOpenAudioSource());
        Vector2 dashPos = transform.position + (_dirFacing * dashDistance);
        transform.position = dashPos;
    }
}
