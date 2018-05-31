using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HealthPickUp : MonoBehaviour
{

    public PlayerHealth currentHealth;
    public AudioSource healthFx;

    public int addAmount = 1;

    void Start()
    {
        currentHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();

        healthFx = GameObject.Find("AudioSourceHearth").GetComponent<AudioSource>();

    }

    void OnTriggerEnter(Collider obj)
    {
        if(obj.gameObject.tag == "Player")
        {
            healthFx.Play();

            currentHealth.currentHealth += addAmount;

            gameObject.SetActive(false);
            //Destroy(gameObject, 2);


            //AudioSource.PlayClipAtPoint(coinFx, new Vector3 (transform.position.x, transform.position.y, transform.position.z - 31.6f));

        }
    }
}