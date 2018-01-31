﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestInteraction : MonoBehaviour
{

    public bool drop;
    public GameObject dropItem;
    public bool playerNear;

    Animator anim;


    // Use this for initialization
    void Start ()
    {
        playerNear = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(playerNear && Input.GetButtonDown("Interact"))
        {
            //Destroy(gameObject);
            Debug.Log("Destroy chest");
        }
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            playerNear = true;
        }

    }

    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            playerNear = false;
        }
    }
}
