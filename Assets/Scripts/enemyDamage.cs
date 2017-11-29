using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDamage : MonoBehaviour
{
    public float damage;
    public float damageRate;
    public float pushBackForce;

    float nextDamage;

    bool playerInRange = false;

    GameObject player;
    PlayerHealth playerHealth;

    // Use this for initialization
    void Start()
    {
        nextDamage = Time.time;
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();

    }

    // Update is called once per frame
    void Update()
    {
        if (playerInRange) Attack();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerInRange = true;
        }
    }

    void OnTriggerExit(Collider other)
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
            playerHealth.addDamage(damage);
            nextDamage = Time.time + damageRate;

            pushBack(player.transform);
        }
    }

    void pushBack (Transform pushedObject)
    {
        Vector3 pushDirection = new Vector3((pushedObject.position.x - transform.position.x), 0, 0).normalized;
        pushDirection *= pushBackForce;


        Rigidbody pushedRb = pushedObject.GetComponent<Rigidbody>();
        pushedRb.velocity = Vector3.zero;
        pushedRb.AddForce(pushDirection, ForceMode.Impulse);
    }

    
}
