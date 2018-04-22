using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toss : MonoBehaviour 
{
    public GameObject grenade;
    public GameObject dbl;

	void Update () 
    {
		if (Input.GetKeyDown(KeyCode.B))
        {
            Throw ();
        }
	}

    public void Throw ()
    {
        var dirToss = this.transform.right;
        GameObject tosser = Instantiate(grenade, transform.position + dirToss, Quaternion.identity);
        tosser.GetComponent<Rigidbody2D>().AddForce(dirToss * 300); // + Vector3.up * 200);
    }
}
