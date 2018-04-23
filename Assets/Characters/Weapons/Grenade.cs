using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RoboRyanTron.Unite2017.Events;

public class Grenade : MonoBehaviour 
{
	public AudioEvent throwSound;
    public AudioEvent explodeSound;
    public AudioEvent hitGroundSound;
    public GameObject explosion;
    
    void Awake () 
    {
        StartCoroutine(DamageArea());
        if (throwSound)
        {
            throwSound.Play(SoundManager.Instance.GetOpenAudioSource());
        }
	}

    void OnDrawGizmosSelected () {
        var c = Color.yellow;
        c.a = 0.5f;
        Gizmos.color = c;
        Gizmos.DrawSphere(transform.position, 1);
    }

    IEnumerator DamageArea ()
    {
        yield return new WaitForSeconds(2f);

        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, 1.5f, Vector2.up, 0f, 1 << LayerMask.NameToLayer("Obstacle"));
        if (hits != null)
        {
            foreach(RaycastHit2D hit in hits)
            {
                Debug.Log(hit.collider.name);

                Component damageableComponent = hit.collider.gameObject.GetComponent(typeof(IDamageable)); // nullable value

			    if (damageableComponent)
			    {
				    (damageableComponent as IDamageable).TakeDamage(10);
                    Instantiate(explosion, transform.position, Quaternion.identity);
				    Destroy(this.gameObject);
			    }
		    }
        }
        else
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }

    private void OnDestroy()
    {
        explodeSound.Play(SoundManager.Instance.GetOpenAudioSource()); 
    }

    
}
