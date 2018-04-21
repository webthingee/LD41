using UnityEngine;
using RoboRyanTron.Unite2017.Variables;
using Random = UnityEngine.Random;

[CreateAssetMenu(menuName="Audio Events/Random")]
public class RandomAudioEvent : AudioEvent
{
	public AudioClip[] clips;
    public FloatReference volumeAdjust;

	public RangedFloat volume;
    #if UNITY_EDITOR
	[MinMaxRange(0, 2)]
        #endif
	public RangedFloat pitch;


	public override void Play(AudioSource source)
	{
		if (clips.Length == 0) return;

		source.clip = clips[Random.Range(0, clips.Length)];
		source.volume = Random.Range(volume.minValue, volume.maxValue) * volumeAdjust;
		source.pitch = Random.Range(pitch.minValue, pitch.maxValue);
		source.Play();
	}

}