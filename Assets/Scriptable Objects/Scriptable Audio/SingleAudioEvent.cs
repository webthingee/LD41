using UnityEngine;
using RoboRyanTron.Unite2017.Variables;

[CreateAssetMenu(menuName="Audio Events/Single")]
public class SingleAudioEvent : AudioEvent
{
	public AudioClip clip;
    public FloatReference volumeAdjust;

	[Range(0,1)] public float volume = 1;
	[Range(-3,3)] public float pitch = 1;

	public override void Play(AudioSource source)
	{
		source.clip = clip;
		source.volume = volume * volumeAdjust;
		source.pitch = pitch;
		source.Play();
	}
}