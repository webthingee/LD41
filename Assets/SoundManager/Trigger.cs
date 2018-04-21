using UnityEngine;

public class Trigger : MonoBehaviour
{
    public AudioEvent audioEvent;
    public bool interuptable;
    AudioSource sm;

	public void OnMouseDown ()
	{
		sm = SoundManager.Instance.GetOpenAudioSource();
        audioEvent.Play(sm);
	}	
    
    public void OnMouseUp ()
	{
        if (interuptable)
            sm.Stop();
	}
}
