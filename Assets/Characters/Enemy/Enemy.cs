using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character 
{	
	[Header("Enemy Settings")]
    public int damage;

    protected override void Start () 
    {
        base.Start();
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Component damageableComponent = other.gameObject.GetComponent(typeof(IDamageable)); // nullable value
		if (other.gameObject.tag == "Player") 
		{
            // if (damageableComponent)
			// {
				other.GetComponent<Player>().CardRemove();
			// }
        }
    }

}
