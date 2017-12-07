using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public float fullHealth;
    public float currentHealth;

    public float pushBackForce;

    public Rigidbody rb;

    // Use this for initialization
    void Start ()
    {
        currentHealth = fullHealth;
		
	}
	
	// Update is called once per frame
	void Update ()
    {

		
	}

    public void addDamage (float damage, float pos)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            playerDeath();

        }

        pushBack(pos);

    }

    public void playerDeath()
    {
        Destroy(gameObject);
    }


    //estremece izquierda else estremece derecha
    void pushBack(float pos)

    {
        if (pos < 1)
            pushBackForce = 1;


        else
            pushBackForce = -1;


        Vector3 pushDirection = new Vector3(pushBackForce, 0, 0).normalized;
        pushDirection *= pushBackForce;

        rb.velocity = Vector3.zero;
        rb.AddForce(pushDirection, ForceMode.Impulse);
    }

}
