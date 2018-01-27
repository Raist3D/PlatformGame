using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionBehaviour : MonoBehaviour
{
    public int potionDamage;
    public int timeExplode;
    public CapsuleCollider radiusDamage;

    // Use this for initialization
    void Start ()
    {
        timeExplode = -1;
        radiusDamage.enabled = false;
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

    void OnTriggerEnter(Collider potionTrigger)
    {
        if(potionTrigger.tag == "Enemy")
        {
            enemyHealth doDamage = potionTrigger.GetComponent<enemyHealth>();
            doDamage.AddDamage(potionDamage);
            timeExplode = 2;
            radiusDamage.enabled = true;
            //doDamage.DamageFX(transform.position, transform.localEulerAngles);
        }
        if(potionTrigger.tag == "Interactuable")
        {
            DestroyItems doDamage = potionTrigger.GetComponent<DestroyItems>();
            doDamage.AddDamage(potionDamage);
            timeExplode = 2;
            radiusDamage.enabled = true;
            //doDamage.DamageFX(transform.position, transform.localEulerAngles);
            Debug.Log(potionTrigger.gameObject.layer);
        }
        if(potionTrigger.tag == "Ground")
        {
            timeExplode = 2;
            radiusDamage.enabled = true;
        }

    }

}
