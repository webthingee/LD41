using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour 
{
    public string title;
    public string description;
    public int numUses;

    public Text titleUI;
    public Text descriptionUI;
    public Text numUsesUI;

    public int NumUses
    {
        get
        {
            return numUses;
        }

        set
        {
            numUses = value;
            if (numUses <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }

    void Start () 
    {
		titleUI.text = title;
		descriptionUI.text = description;
		numUsesUI.text = numUses.ToString();

	}
	
	void Update () 
    {
		numUsesUI.text = numUses.ToString();
	}

    public void CardUsed ()
    {
        NumUses --;
    }
}
