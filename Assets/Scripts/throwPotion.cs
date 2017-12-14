using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class throwPotion : MonoBehaviour
{
    public float damage;
    public float speed;

    Rigidbody rb;

	// Use this for initialization
	void Start ()
    {
        rb = GetComponentInParent<Rigidbody>();

        if(transform.rotation.y > 0) rb.AddForce(Vector3.right * speed, ForceMode.Impulse);
        else rb.AddForce(Vector3.right *-speed, ForceMode.Impulse);
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

   void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer ("Attackable"))
        {
            rb.velocity = Vector3.zero;
            Destroy(gameObject);
        }
    }

}
