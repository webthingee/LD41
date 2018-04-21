using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FiringCtrl : MonoBehaviour 
{
	//private Weapon weapon;
    public bool canFire = true;
    public GameObject projectile;
    public float projectileSpeed;
    public float rateOfFire;

    // void Awake()
    // {
    //     weapon = GetComponent<WeaponInHand>().primaryWeapon;
    // }

    public void PullTrigger ()
    {
        if (canFire)
            StartCoroutine(FireBullets(transform.up, rateOfFire));
    }

	IEnumerator FireBullets (Vector3 _direction, float _waitTime)
	{			
		canFire = false;
				
		Vector3 _position = transform.position;
			_position.z = 0;
		
		GameObject bullet = Instantiate(projectile, _position, Quaternion.identity);
            bullet.transform.up = _direction;
            bullet.GetComponent<Projectile>().FiringPoint = transform.position;
            bullet.GetComponent<Projectile>().projectileSpeed = projectileSpeed;
            //bullet.GetComponent<Projectile>().projectileRange = weapon.Range;            

		yield return new WaitForSeconds(_waitTime);
		
		canFire = true;
	}
}
