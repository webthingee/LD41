using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour 
{
    public GameObject playerContainer;
    Animator anim;
    CharacterMovement cm;

    public AudioEvent audioEvent;
    public float stepSpeed;
    AudioSource sm;
    bool walking;
    IEnumerator walkingSounds;
        
    void Awake ()
    {
        cm = GetComponent<CharacterMovement>();
        anim = GetComponentInChildren<Animator>();
        walkingSounds = WalkingSounds();      
    }

    void Update ()
    {        
        //float yAxis = Input.GetAxis("Vertical");
        ChangeDirection(cm.GetMoveDirection.x);

        anim.SetFloat("Forward", Mathf.Abs(cm.GetMoveDirection.x));
        //anim.SetFloat("Looking", yAxis);

        walking = Mathf.Abs(cm.GetMoveDirection.x) > 0 ? true : false;
        if (walking)
        {
            StartWalking();
        }
        else
        {
            StopWalking();
        }
    }

    void ChangeDirection (float _direction)
    {        
        /// Rotate Player
        if (_direction > 0) playerContainer.transform.eulerAngles = new Vector3(0, 0, 0);
        if (_direction < 0) playerContainer.transform.eulerAngles = new Vector3(0, 180, 0);
    }

    public void StartWalking ()
	{
        if (!sm)
        {
            sm = SoundManager.Instance.GetOpenAudioSource();
            StartCoroutine(walkingSounds);
        }
	}
    
    public void StopWalking ()
	{
        StopCoroutine(walkingSounds);
        sm = null;
	}

    IEnumerator WalkingSounds ()
    {
        while (true)
        {
            audioEvent.Play(sm);
            yield return new WaitForSeconds(stepSpeed);
        }
    }
}
