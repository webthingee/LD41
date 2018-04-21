using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Card : MonoBehaviour, IPointerClickHandler, IPointerExitHandler, IPointerEnterHandler
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

    // void Awake ()
    // {
    //     usesRemaining = Random.Range(1, cardData.numUses + 1);
    //     graphic.texture = cardData.graphic;
    //     graphic.color = cardData.tintColor;
    // }

    void Start () 
    {
		usesRemaining = Random.Range(1, cardData.numUses + 1);
        graphic.texture = cardData.graphic;
        graphic.color = cardData.tintColor;
        titleUI.text = cardData.title;
		descriptionUI.text = cardData.description;
		numUsesUI.text = cardData.numUses.ToString();
	}
	
	void Update () 
    {
		numUsesUI.text = usesRemaining.ToString();
	}


    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left) {
            ExecuteCardAction();
            Debug.Log("Left Mouse Down: " + eventData.pointerCurrentRaycast.gameObject.name);
        }

        if (eventData.button == PointerEventData.InputButton.Right) {
            Debug.Log("Right Mouse Down: " + eventData.pointerCurrentRaycast.gameObject.name);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Mouse Enter");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Mouse Exit");
    }

    public void ExecuteCardAction ()
    {
        NumUses --;
        cardData.cardEffect.Raise();
    }

}
