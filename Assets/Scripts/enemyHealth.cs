using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyHealth : MonoBehaviour
{

    public float enemyMaxHealth;
    public float currentHealth;
    public float damageModifier;
    //public GameObject damageParticles;

    public bool drop;
    public GameObject dropItem;

    public AudioClip deathSound;
    public bool canBurn;
    public float burnDamage;
    public float burnTime;
    //public GameObject burnEffects;

    bool onFire;
    float nextBurn;
    public float burnInterval;
    float endBurn;

    public Slider enemyHealthSlider;
    AudioSource enemyAudioSource;


	// Use this for initialization
	void Start ()
    {
        currentHealth = enemyMaxHealth;
        enemyHealthSlider.maxValue = enemyMaxHealth;
        enemyHealthSlider.value = currentHealth;
        enemyAudioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(onFire && Time.time>nextBurn)
        {
            addDamage(burnDamage);
            nextBurn += burnInterval;
        }
        if(onFire && Time.time>endBurn)
        {
            onFire = false;
            //burnEffects.SetActive(false);
        }
	}

    public void addDamage (float damage)
    {
        enemyHealthSlider.gameObject.SetActive(true);
        damage = damage * damageModifier;

        if (damage <= 0f) return;
        currentHealth -= damage;

        enemyHealthSlider.value = currentHealth;
        enemyAudioSource.Play();

        if (currentHealth <= 0) makeDead();
    }

    public void damageFX (Vector3 point, Vector3 rotation)
    {
        //Instantiate(damageParticles, point, Quaternion.Euler(rotation));
    }

    public void addFire()
    {
        if (!canBurn) return;
        onFire = true;
        //burnEffects.SetActive(true);
        endBurn = Time.time + burnTime;
        nextBurn = Time.time + burnInterval;
    }

    void makeDead ()
    {
        //quitar movimiento

        AudioSource.PlayClipAtPoint(deathSound, transform.position, 0.5f);

        Destroy(gameObject.transform.root.gameObject);

        if (drop) Instantiate(dropItem, transform.position, transform.rotation);
    }
}
