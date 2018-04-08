using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PickUpLoot : MonoBehaviour
{

    Currency currentGold;
    public AudioSource coinFx;

    public int addAmount;

    void Start()
    {
        currentGold = GameObject.FindGameObjectWithTag("GameController").GetComponent<Currency>();

        coinFx = GameObject.Find("AudioSourceCoin").GetComponent<AudioSource>();

    }

    void OnTriggerEnter(Collider obj)
    {
        if(obj.gameObject.tag == "Player")
        {
            currentGold.gold += addAmount;

            coinFx.Play();

            gameObject.SetActive(false);
            //Destroy(gameObject, 2);


            //AudioSource.PlayClipAtPoint(coinFx, new Vector3 (transform.position.x, transform.position.y, transform.position.z - 31.6f));

        }
    }
}