using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bossHealth : MonoBehaviour
{

    public float enemyMaxHealth;
    public float currentHealth;
    public float damageModifier;
    //public GameObject damageParticles;

    public bool drop;
    public GameObject dropItem;

    public bool canBurn;
    public float burnDamage;
    public float burnTime;
    //public GameObject burnEffects;

    bool onFire;
    float nextBurn;
    public float burnInterval;
    float endBurn;

    public EnemyBehaviour enemyBh;

    public Slider enemyHealthSlider;
    public AudioSource victoryFx;



    // Use this for initialization
    void Start()
    {
        currentHealth = enemyMaxHealth;
        enemyHealthSlider.maxValue = enemyMaxHealth;
        enemyHealthSlider.value = currentHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(onFire && Time.time > nextBurn)
        {
            AddDamage(burnDamage);
            nextBurn += burnInterval;
        }
        if(onFire && Time.time > endBurn)
        {
            onFire = false;
            //burnEffects.SetActive(false);
        }
    }

    public void AddDamage(float damage)
    {

        enemyHealthSlider.gameObject.SetActive(true);
        damage = damage * damageModifier;

        if(damage <= 0f) return;
        currentHealth -= damage;

        enemyHealthSlider.value = currentHealth;
        //enemyAudioSource.Play();

        enemyBh.Stun();


        if(currentHealth <= 0) MakeDead();
    }

    public void DamageFX(Vector3 point, Vector3 rotation)
    {
        //Instantiate(damageParticles, point, Quaternion.Euler(rotation));
    }

    public void AddFire()
    {
        if(!canBurn) return;
        onFire = true;
        //burnEffects.SetActive(true);
        endBurn = Time.time + burnTime;
        nextBurn = Time.time + burnInterval;
    }

    void MakeDead()
    {
        //quitar movimiento
        victoryFx.Play();

        Destroy(gameObject.transform.root.gameObject);

        if(drop) Instantiate(dropItem, transform.position, transform.rotation);




    }
}
