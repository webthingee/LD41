﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour 
{
    public GameObject playerContainer;
    Animator anim;
    CharacterMovement cm;
        
    void Awake ()
    {
        cm = GetComponent<CharacterMovement>();
        anim = GetComponentInChildren<Animator>();
    }

    void Update ()
    {        
        //float yAxis = Input.GetAxis("Vertical");
        ChangeDirection(cm.GetMoveDirection.x);

        anim.SetFloat("Forward", Mathf.Abs(cm.GetMoveDirection.x));
        //anim.SetFloat("Looking", yAxis);
    }

    void ChangeDirection (float _direction)
    {        
        /// Rotate Player
        if (_direction > 0) playerContainer.transform.eulerAngles = new Vector3(0, 0, 0);
        if (_direction < 0) playerContainer.transform.eulerAngles = new Vector3(0, 180, 0);
    }
}
