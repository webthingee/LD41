using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FiringCtrl : MonoBehaviour 
{
    public bool canFire = true;
    public GameObject projectile;
    public float projectileSpeed;
    public float rateOfFire = 1.0f;
    public int damage = 1;
    public bool doubleDamage;
    public CardData cardData;

    public void PullTrigger ()
    {
        if (canFire)
        {
            StartCoroutine(FireBullets(transform.up, damage, rateOfFire));
            doubleDamage = false;
        }
    }

	IEnumerator FireBullets (Vector3 _direction, int _damage, float _waitTime)
	{			
		canFire = false;
				
		Vector3 _position = transform.position;
			_position.z = 0;
		
		GameObject bullet = Instantiate(projectile, _position, Quaternion.identity);
            bullet.transform.up = _direction;
            bullet.GetComponent<Projectile>().FiringPoint = transform.position;
            bullet.GetComponent<Projectile>().projectileSpeed = projectileSpeed;
            int newDamage = doubleDamage ? 2 : 1;
            bullet.GetComponent<Projectile>().damage = _damage * newDamage; // calc before it gets here
            //bullet.GetComponent<Projectile>().projectileRange = weapon.Range;            

		yield return new WaitForSeconds(_waitTime);
		
		canFire = true;
	}

    public void DoubleDamage ()
    {
        doubleDamage = true;
    }
}
