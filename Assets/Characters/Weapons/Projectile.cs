using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour 
{
    [ShowOnly] public float projectileSpeed;
    public float projectileRange;
	public GameObject impactEffect;

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
}
