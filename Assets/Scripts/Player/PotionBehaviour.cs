using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionBehaviour : MonoBehaviour
{
    public Rigidbody rb;

    public int potionDamage;
    public int timeExplode;
    public CapsuleCollider radiusDamage;

    public bool gravity;

    public AudioClip boxDestroyFx;
    public AudioSource potionAS;
 
    // Use this for initialization
    void Start ()
    {
        timeExplode = -1;
        radiusDamage.enabled = false;
        gravity = true;

    }

    // Update is called once per frame
    void Update ()
    {
        if(timeExplode>0)
        {
            timeExplode--;
            if(timeExplode==0)
            {
                Destroy(gameObject);
                timeExplode = -1;
            }
        }
           
	}

    void FixedUpdate()
    {
        rb.AddForce(0, -49, 0);

    }


    void OnTriggerEnter(Collider potionTrigger)
    {


        if(potionTrigger.tag == "Enemy")
        {
            enemyHealth doDamage = potionTrigger.GetComponent<enemyHealth>();
            doDamage.AddDamage(potionDamage);
            AudioSource.PlayClipAtPoint(boxDestroyFx, new Vector3(transform.position.x, transform.position.y, transform.position.z - 35f));

            timeExplode = 2;
            radiusDamage.enabled = true;
            //doDamage.DamageFX(transform.position, transform.localEulerAngles);
        }
        if(potionTrigger.tag == "Interactuable")
        {
            DestroyItems doDamage = potionTrigger.GetComponent<DestroyItems>();
            doDamage.AddDamage(potionDamage);
            AudioSource.PlayClipAtPoint(boxDestroyFx, new Vector3(transform.position.x, transform.position.y, transform.position.z - 35f));

            timeExplode = 2;
            radiusDamage.enabled = true;
            //doDamage.DamageFX(transform.position, transform.localEulerAngles);
        }
        if(potionTrigger.tag == "Ground")
        {
            AudioSource.PlayClipAtPoint(boxDestroyFx, new Vector3 (transform.position.x, transform.position.y, transform.position.z - 31.5f));

            timeExplode = 2;
            radiusDamage.enabled = true;
        }

    }

}
