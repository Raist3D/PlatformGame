﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShot : MonoBehaviour
{
    public float shotRatio;
    public GameObject fireBall;
    public float nextShot;
    public Transform playerTransform;
    private float distX;
    private float distY;

    // Use this for initialization
    void Start ()
    {
        nextShot = Time.time + shotRatio;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(Time.time > nextShot)
        {
            GameObject shot = Instantiate(fireBall);
            shot.transform.position = new Vector3(transform.position.x - 3, transform.position.y + 3, 0);
            //distX = transform.position.x - playerTransform.position.x;
            //distY = transform.position.y - playerTransform.position.y;
            shot.GetComponent<Rigidbody>().velocity = new Vector3 (-3, 0, 0);
            nextShot = Time.time + shotRatio;
        }


    }
}
