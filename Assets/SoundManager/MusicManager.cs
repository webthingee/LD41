using UnityEngine;

public class MusicManager : MonoBehaviour 
{
    public MusicAudioEvent audioEvent;
    AudioSource audioSource;

    void Awake ()
    {
        audioSource = GetComponent<AudioSource>();
    }
    
    void Start ()
    {
        audioEvent.Play(audioSource);
	}

    public void AdjustVolume ()
    {
        audioSource.volume = audioEvent.AdjustedAudio();
    }
}
