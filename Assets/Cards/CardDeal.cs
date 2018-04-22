using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDeal : MonoBehaviour 
{
    public GameObject cardArea;
    public GameObject card;

    public CardData[] cardData;
    
    public void DealACard (int _num)
    {
        for (int i = 0; i < _num; i++)
        {
            GameObject newCard = Instantiate(card, cardArea.transform.position, card.transform.rotation, cardArea.transform);
            newCard.GetComponent<Card>().cardData = cardData[Random.Range(0, cardData.Length)];            
        }
    }
}
