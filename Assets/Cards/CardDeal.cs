using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDeal : MonoBehaviour 
{
    public GameObject cardArea;
    public GameObject card;

    public CardData[] cardData;

    private void Start()
    {
        DealACard();
        DealACard();
        DealACard();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.M))
        {
            DealACard();
        }
    }
    
    public void DealACard ()
    {
        GameObject newCard = Instantiate(card, cardArea.transform.position, card.transform.rotation, cardArea.transform);
        newCard.GetComponent<Card>().cardData = cardData[Random.Range(0, cardData.Length)];
    }

    public void RandomCardDetails ()
    {

    }
}
