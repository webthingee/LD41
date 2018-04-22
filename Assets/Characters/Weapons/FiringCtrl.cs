using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FiringCtrl : MonoBehaviour 
{
    public bool canFire = true;
    public GameObject projectile;
    public Transform gunPoint;
    public float projectileSpeed;
    public float rateOfFire = 1.0f;
    public bool doubleDamage;
    public int damage = 1;

    public void DoubleDamage ()
    {
        doubleDamage = true;
    }

    public void PullTrigger ()
    {
        if (canFire)
        {
            StartCoroutine(FireBullets(transform.right, damage, rateOfFire));
        }
    }

	IEnumerator FireBullets (Vector3 _direction, int _damage, float _waitTime)
	{			
		canFire = false;
				
		Vector3 _position = gunPoint.position;
			_position.z = 0;
		
		GameObject bullet = Instantiate(projectile, _position, Quaternion.identity);
            bullet.transform.up = _direction;
            bullet.GetComponent<Projectile>().FiringPoint = gunPoint.position;
            bullet.GetComponent<Projectile>().projectileSpeed = projectileSpeed;
            bullet.GetComponent<Projectile>().damage = CalculateDamage(); // calc before it gets here
            //bullet.GetComponent<Projectile>().projectileRange = weapon.Range;            

		yield return new WaitForSeconds(_waitTime);
        
        doubleDamage = false;
		
		canFire = true;
	}

    int CalculateDamage ()
    {
        // if (cardData.damageBonus > 0)
        // {
        //     damageToDo += cardData.damageBonus;
        // }

        if (doubleDamage)
        {
            damage *= 2;
        }

        return damage;
    }
}
