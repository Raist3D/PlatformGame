﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PickUpLoot : MonoBehaviour
{

    public Currency currentGold;
    public AudioSource coinFx;

    public int addAmount;

    void Start()
    {
        currentGold = GameObject.Find("Currency").GetComponent<Currency>();

        coinFx = GameObject.Find("AudioSourceCoin").GetComponent<AudioSource>();

    }

    void OnTriggerEnter(Collider obj)
    {
        if(obj.gameObject.tag == "Player")
        {
            coinFx.Play();

            currentGold.gold += addAmount;

            gameObject.SetActive(false);
            //Destroy(gameObject, 2);


            //AudioSource.PlayClipAtPoint(coinFx, new Vector3 (transform.position.x, transform.position.y, transform.position.z - 31.6f));

        }
    }
}