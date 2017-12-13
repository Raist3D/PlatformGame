using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDamage : MonoBehaviour
{

    public float damage;
    //public float damageRate;
    public Vector2 directionForce;

   // float nextDamage;

//bool playerInRange = false;
    

    // Use this for initialization
    void Start()
    {
       // nextDamage = Time.time;
        //player = GameObject.FindGameObjectWithTag("Player");
        //playerHealth = player.GetComponent<PlayerHealth>();

    }

    // Update is called once per frame
    void Update()
    {
        //if (playerInRange) Attack();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //playerInRange = true;
            DamagePlayer(other.gameObject);

        }
    }
    void DamagePlayer(GameObject who)
    {
        who.GetComponent<PlayerHealth>().AddDamage(damage);

        Vector3 dir = directionForce;
        if(who.transform.position.x < this.transform.position.x) dir.x *= -1;

        Rigidbody rb = who.GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;

        rb.AddForce(dir, ForceMode.Impulse);
    }

  /*  void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerInRange = false;
        }
    }

    void Attack()
    {
        if (nextDamage <= Time.time)
        {
            playerHealth.addDamage(damage, player.transform.position.x - transform.position.x);
            nextDamage = Time.time + damageRate;
        }
    }
    */
    /*void pushBack (Transform pushedObject)
    {
        
        Vector3 pushDirection = new Vector3((pushedObject.position.x - transform.position.x), 0, 0).normalized;
        pushDirection *= pushBackForce;

        Rigidbody pushedRb = pushedObject.GetComponent<Rigidbody>();
        pushedRb.velocity = Vector3.zero;
        pushedRb.AddForce(pushDirection, ForceMode.Impulse);

    }*/

    //llamas a damage de PlayerHealth y le paso (damage, pushedObject.position.x - transform.position.x
    
}
