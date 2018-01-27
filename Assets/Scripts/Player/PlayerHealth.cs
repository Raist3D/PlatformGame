using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerHealth : MonoBehaviour
{

    public float fullHealth;
    public float currentHealth;
    public bool isImmune;

    public float pushBackForce;

    public Rigidbody rb;

    public PlayerBehaviour playerBh;

    // Use this for initialization
    void Start ()
    {
        currentHealth = fullHealth;
        isImmune = false;
	}
	
	// Update is called once per frame
	void Update ()
    {

		
	}

    public void AddDamage (float damage, Vector3 knock)// float pos)
    {
        if(!playerBh.immune)
        {
            playerBh.Stun(knock);

            currentHealth -= damage;

            if(currentHealth <= 0)
            {
                playerDeath();
                SceneManager.LoadScene("DefeatScene");
            }
        }
    }

    public void playerDeath()
    {
        Destroy(gameObject);
    }


    //estremece izquierda else estremece derecha
    void PushBack(float pos)
    {
        Debug.Log("PUSH");
        if (pos < 1)
            pushBackForce = 1;


        else
            pushBackForce = -1;


        Vector3 pushDirection = new Vector3(pushBackForce, 1, 0).normalized;
        pushDirection *= pushBackForce;

        rb.velocity = Vector3.zero;
        rb.AddForce(pushDirection, ForceMode.Impulse);
    }

}
