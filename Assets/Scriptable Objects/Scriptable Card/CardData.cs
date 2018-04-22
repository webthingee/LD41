using UnityEngine;
using RoboRyanTron.Unite2017.Variables;
using RoboRyanTron.Unite2017.Events;

[CreateAssetMenu(menuName="Card/Data")]
public class CardData : ScriptableObject
{
	public string title;
    public string description;
    public int numUses;
    public string targetObject;

    public Texture graphic;
    public Color tintColor = Color.white;
    
    public GameEvent cardEffect;

    public GameObject weapon;
    public bool doubleDamage;
    public int damageBonus;

    public AudioClip clips;
}
