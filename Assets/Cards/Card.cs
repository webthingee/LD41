using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour 
{
    public CardData cardData;
    public int usesRemaining;

    [Header("UI")]
    public RawImage graphic;
    public Text titleUI;
    public Text descriptionUI;
    public Text numUsesUI;

    public int NumUses
    {
        get
        {
            return usesRemaining;
        }

        set
        {
            usesRemaining = value;
            if (usesRemaining <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }

    void Awake ()
    {
        usesRemaining = Random.Range(1, cardData.numUses + 1);
        graphic.texture = cardData.graphic;
        graphic.color = cardData.tintColor;
    }

    void Start () 
    {
		titleUI.text = cardData.title;
		descriptionUI.text = cardData.description;
		numUsesUI.text = cardData.numUses.ToString();
	}
	
	void Update () 
    {
		numUsesUI.text = usesRemaining.ToString();
	}

    public void ExecuteCardAction ()
    {
        NumUses --;
        cardData.cardEffect.Raise();
    }
}
