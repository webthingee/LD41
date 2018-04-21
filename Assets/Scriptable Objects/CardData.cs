using UnityEngine;
using RoboRyanTron.Unite2017.Variables;
using RoboRyanTron.Unite2017.Events;

[CreateAssetMenu(menuName="Card/Data")]
public class CardData : ScriptableObject
{
	public string title;
    public string description;
    public int numUses;
    public Texture graphic;
    public Color tintColor;
    public GameEvent cardEffect;

    public AudioClip clips;
}
