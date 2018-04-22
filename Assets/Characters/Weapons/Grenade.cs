using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour {

	// Use this for initialization
	void Start () 
    {
        Invoke("DamageArea", 2f);

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnDrawGizmosSelected() {
        var c = Color.yellow;
        c.a = 0.5f;
        Gizmos.color = c;
        Gizmos.DrawSphere(transform.position, 1);
    }

    void DamageArea ()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, 1f, Vector2.up, 0f, 1 << LayerMask.NameToLayer("Obstacle"));
        if (hits != null)
        {
            foreach(RaycastHit2D hit in hits)
            {
                Debug.Log(hit.collider.name);

                Component damageableComponent = hit.collider.gameObject.GetComponent(typeof(IDamageable)); // nullable value

			    if (damageableComponent)
			    {
				    (damageableComponent as IDamageable).TakeDamage(10);
				    Destroy(this.gameObject);
			    }
		    }

        }

    }

    
}
