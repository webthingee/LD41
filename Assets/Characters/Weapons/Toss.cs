using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toss : MonoBehaviour 
{
    public GameObject grenade;

	void Update () 
    {
		if (Input.GetKeyDown(KeyCode.B))
        {
            var dirToss = this.transform.right;
            GameObject tosser = Instantiate(grenade, transform.position + Vector3.up, Quaternion.identity);
            tosser.GetComponent<Rigidbody2D>().AddForce((dirToss + Vector3.up) * 200);
        }
	}
}
