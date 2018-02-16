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
    public AudioSource itemAS;
    public AudioClip itemDestroyFx;


    MeleeAttack meleeAtk;


    // Use this for initialization
    void Start ()
    {
        meleeAtk = gameObject.GetComponent<MeleeAttack>();
        itemAS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update ()
    {

	}

    void OnTriggerEnter(Collider meleeAtk)
    {

        if(meleeAtk.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
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
