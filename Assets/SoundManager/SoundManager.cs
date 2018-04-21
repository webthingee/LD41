using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour 
{
    public static SoundManager Instance;
    
    [Tooltip("Minimum number of Audio Sources to keep alive")]
    [Range(1,5)] public int minSources = 1;

    [Tooltip("Countdown after a played clip to execute a clean up of sources")]
    [Range(1,10)] public int cleanUpInterval = 5;
    
    bool hasScheduledCleanup;
    List<AudioSource> audioSources = new List<AudioSource>();

    void Awake ()
    {
        // Create as a singleton
        Instance = this;
        // Populate the initial List<> of Audio Source Components
        BuildAudioSourcesList();
    }

    /// Return first Audio Source that is not playing an audio clip
    public AudioSource GetOpenAudioSource ()
    {        
        int _audioSourcesTried = 0;

        if (audioSources.Count > 0)
        {
            if (!hasScheduledCleanup)
            {
                StartCoroutine(CleanUpAudioSources());
                hasScheduledCleanup = true;
            }

            foreach (AudioSource _audioSource in audioSources.ToArray())
            {
                _audioSourcesTried++;
                
                if (!_audioSource.isPlaying)
                {
                    return _audioSource;
                }

                if (_audioSourcesTried >= audioSources.Count)
                {
                    AudioSource newAudioSource = this.gameObject.AddComponent<AudioSource>();
                    newAudioSource.playOnAwake = false;
                    audioSources.Add(newAudioSource);
                    return newAudioSource;
                }
            }
        }
        // If we get here, we got a problem.
        Debug.LogError("Unable to acces or create AudioSource component");
        return null;
    }

    /// Builds the initial List<> of Audio Source Componenets in the GameObject
    void BuildAudioSourcesList ()
    {
        foreach (AudioSource _audioSource in GetComponents<AudioSource>())
        {
            audioSources.Add(_audioSource);
        }
    }

    /// Cleans the List<> of Audio Source Componenets in the GameObject
    IEnumerator CleanUpAudioSources ()
    {
        yield return new WaitForSeconds(cleanUpInterval);
        
        int _audioSourcesToTry = minSources;
        
        foreach (AudioSource _audioSource in audioSources.ToArray())
        {
            if (!_audioSource.isPlaying && _audioSourcesToTry < audioSources.Count)
            {
                audioSources.Remove(_audioSource);
                Destroy(_audioSource);
            }
            _audioSourcesToTry++;
        }

        hasScheduledCleanup = false;
    }
}
