using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public float fullHealth;
    public float currentHealth;

	// Use this for initialization
	void Start ()
    {
        currentHealth = fullHealth;
		
	}
	
	// Update is called once per frame
	void Update ()
    {

		
	}

    public void hitDamage (float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            playerDeath();
        }
    }
    public void playerDeath()
    {
        Destroy(gameObject);
    }
}
