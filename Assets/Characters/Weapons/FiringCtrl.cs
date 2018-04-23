using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using RoboRyanTron.Unite2017.Events;

public class FiringCtrl : MonoBehaviour 
{
    public bool canFire = true;
    public float enemySight;
    public GameObject projectile;
    public Transform gunPoint;
    public float projectileSpeed;
    public float rateOfFire = 1.0f;
    public bool doubleDamage;
    public GameObject doubleDamageInd;
    public int damage = 1;
    public AudioEvent fireSound;

    public bool isEnemy;
    
    private void Awake()
    {
        if (!isEnemy)
        {
            doubleDamageInd = GetComponentInParent<Toss>().dbl;
            doubleDamageInd.SetActive(false);
        }
    }

    private void Update()
    {
        if (isEnemy)
            EnemyTargeting();
    }

    IEnumerator FireAtRandom ()
    {
        PullTrigger();        
        yield return new WaitForSeconds(1f);
    }

    public void DoubleDamage ()
    {
        doubleDamage = true;
        doubleDamageInd.SetActive(true);
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

        if (fireSound)
            fireSound.Play(SoundManager.Instance.GetOpenAudioSource()); 
        
        yield return new WaitForSeconds(_waitTime);
        
        doubleDamage = false;
        if (doubleDamageInd)
            doubleDamageInd.SetActive(false);
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

    void EnemyTargeting ()
    {
        Vector3 _dirFacing = transform.right;

        var rayStart = transform.position;
        var rayDir = _dirFacing;
        float rayDist = enemySight;

        Debug.DrawRay(rayStart, rayDir * rayDist, Color.green);

        RaycastHit2D[] hits = Physics2D.RaycastAll(rayStart, rayDir, rayDist, 1 << LayerMask.NameToLayer("Default"));

        if (hits != null)
        {
            foreach(RaycastHit2D hit in hits)
            {
                if (hit.collider.tag == "Player")
                {
                    StartCoroutine(FireAtRandom());
                }
		    }
        }
    }
}
