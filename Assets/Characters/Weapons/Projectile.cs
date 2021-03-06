﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RoboRyanTron.Unite2017.Events;

public class Projectile : MonoBehaviour 
{
    [ShowOnly] public float projectileSpeed;
    public float projectileRange;
	public GameObject impactEffect;
    public bool damageHero;
    public int damage;

    Vector2 firingPoint;

    public Vector2 FiringPoint
    {
        get
        {
            return firingPoint;
        }

        set
        {
            firingPoint = value;
        }
    }

    void Update () 
	{
		/// Move the projectile
        transform.Translate(Vector3.up * projectileSpeed * Time.deltaTime);	
        
        /// Limit how far it can go
        // if (Vector2.Distance(FiringPoint, transform.position) > projectileRange)
        // {
        //     Destroy(this.gameObject);
        // }
	}

    void OnTriggerEnter2D(Collider2D other)
	{
        Component damageableComponent = other.gameObject.GetComponent(typeof(IDamageable)); // nullable value
		if (other.tag == "Enemy" && !damageHero)
		{
			if (damageableComponent)
			{
				(damageableComponent as IDamageable).TakeDamage(damage);
				Destroy(this.gameObject);
			}
		}
        if (other.tag == "Player" && damageHero)
		{
			if (damageableComponent)
			{
				(damageableComponent as IDamageable).TakeDamage(damage);
                other.GetComponent<Player>().CardRemove();
				Destroy(this.gameObject);
			}
		}
	}
}
