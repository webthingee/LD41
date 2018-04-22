using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrizeBox : MonoBehaviour 
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            FindObjectOfType<CardDeal>().DealACard(1);
            Destroy(this.gameObject);
        }
    }
}
