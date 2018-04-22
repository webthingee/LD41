using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : Character 
{
    public Transform weaponAnchor;
    public CardData cardData;
    public List<Card> cards = new List<Card>();

	void Awake ()
    {
		PickUpWeapon();
	}
	
	void Update () 
    {
		CardCheck();
	}

    void CardCheck ()
    {
        cards.Clear();

        foreach (Card card in FindObjectsOfType<Card>())
        {
            if (card.cardData.title == "GunSlinger")
            {
                cards.Insert(0, card);
            }
            else
            {
                cards.Add(card);
            }
        }
    }

    public void CardRemove ()
    {
        Debug.Log("CardRemove");

        if (cards.Count > 1)
        {
            int rand = Random.Range(1, cards.Count);
            Destroy(cards[rand].gameObject);
            CardCheck();
        }
        else
        {
            Debug.Log("YOU ARE DEAD!");
            cards[0].usesRemaining --;

            if (cards[0].usesRemaining > 0) 
            {
                GameObject.Find("Game Manager").GetComponent<GameManager>().reloadImg.SetActive(true);
                Destroy(this.gameObject);
            }
            else
            {
                Debug.Log("GAME OVER");
                GameObject.Find("Game Manager").GetComponent<GameManager>().gameOverImg.SetActive(true);
                Destroy(this.gameObject);
            }
        }
    }

    public void CardDataProcess ()
    {
        if (cardData.weapon != null)
        {
            PickUpWeapon();
        }
    }

    void PickUpWeapon ()
    {
        if (weaponAnchor.GetComponentInChildren<FiringCtrl>() != null)
        {
            Destroy(weaponAnchor.GetComponentInChildren<FiringCtrl>().gameObject);
        }
        Instantiate(cardData.weapon, weaponAnchor.position, weaponAnchor.transform.rotation, weaponAnchor);
    }
}
