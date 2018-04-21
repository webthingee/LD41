using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RoboRyanTron.Unite2017.Events;

public class CardAction : MonoBehaviour 
{
	public GameEvent cardEffect;
    
    private void OnMouseDown ()
    {
        cardEffect.Raise();
        //Debug.Log("Card Effect");
    }
}
