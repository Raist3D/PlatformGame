using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyItems : MonoBehaviour
{

    public float enemyMaxHealth;
    public float currentHealth;
    public float damageModifier;

    public bool drop;
    public GameObject dropItem;



    MeleeAttack meleeAtk;


    // Use this for initialization
    void Start ()
    {
        meleeAtk = gameObject.GetComponent<MeleeAttack>();

    }

    // Update is called once per frame
    void Update ()
    {

	}

    void OnTriggerEnter(Collider meleeAtk)
    {

        if(meleeAtk.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
    public void AddDamage(float damage)
    {

        damage = damage * damageModifier;

        if(damage <= 0f) return;
        currentHealth -= damage;

        //enemyAudioSource.Play();

        if(currentHealth <= 0) MakeDead();
    }

    void MakeDead()
    {
        //quitar movimiento

        //AudioSource.PlayClipAtPoint(deathSound, transform.position, 0.5f);

        Destroy(gameObject.transform.root.gameObject);

        if(drop) Instantiate(dropItem, transform.position, transform.rotation);
    }




}
