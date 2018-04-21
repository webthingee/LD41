using UnityEngine;
using RoboRyanTron.Unite2017.Variables;

[CreateAssetMenu(menuName="Audio Events/Music")]
public class MusicAudioEvent : AudioEvent
{
	public AudioClip clip;
    public FloatReference volumeAdjust;
    [Range(0,1)] public float volume = 1;
    public bool loop = true;

    public float AdjustedAudio ()
    {
        return volume * volumeAdjust;
    }

    public override void Play (AudioSource source)
	{
		source.clip = clip;
		source.volume = AdjustedAudio();
		source.loop = loop;
		source.Play();
	}

    public void Pause (AudioSource source)
	{
		source.Pause();
	}

    public void Stop (AudioSource source)
	{
		source.Stop();
	}
}
