    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class throwPotion : MonoBehaviour
{
    public float damage;
    public float speed;

    public float throwRate;
    public float nextThrow;

    public bool potion;
    public GameObject potionItem;

    Animator anim;
    Rigidbody rb;

	// Use this for initialization
	void Start ()
    {
        rb = GetComponentInParent<Rigidbody>();

        if(transform.rotation.y > 0) rb.AddForce(Vector3.right * speed, ForceMode.Impulse);
        else rb.AddForce(Vector3.right *-speed, ForceMode.Impulse);

        nextThrow = 0f;

    }

// Update is called once per frame
    void Update ()
    {
		
	}
    void FixedUpdate()
    {
        bool throwPotion = Input.GetButtonDown("Fire2");

        if(nextThrow < Time.time)
        {
            if(throwPotion)
            {
                gameObject.SetActive(true);
                nextThrow = Time.time + throwRate;
                if (potion) Instantiate(potionItem, transform.position, transform.rotation);

                //anim.SetTrigger("potionThrow");
            }
        }


    }


    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer ("Attackable"))
        {
            rb.velocity = Vector3.zero;
            Destroy(gameObject);
        }
    }
    
    
    //if (drop) Instantiate(dropItem, transform.position, transform.rotation);


}
