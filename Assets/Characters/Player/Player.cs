using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour 
{
    public Transform weaponAnchor;
    //public GameObject weaponInHand;
    public CardData cardData;

	void Start ()
    {
		PickUpWeapon();
	}
	
	void Update () 
    {
		if (Input.GetKeyDown(KeyCode.N))
        {
            PickUpWeapon();
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
        GameObject weapon = Instantiate(cardData.weapon, weaponAnchor.position, Quaternion.identity, weaponAnchor);
    }
}
