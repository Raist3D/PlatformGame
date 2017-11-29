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
            playerHealth.hitDamage(damage);
            nextDamage = Time.time + damageRate;

            pushBack(player.transform);
        }
    }

    void pushBack (Transform pushedObject)
    {

    }

    
}
