﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossEnemySpawn : MonoBehaviour
{
    public GameObject enemyPrefab;

    private Vector3 enemyPosition;

    public float spawnRatio;
    public float nextEnemy;

    public bool isActive;

    public BoxCollider trigger;

    public AudioSource bossQuote;


    void Start()
    {

    }

    void Update()
    {
        if(generateEnemy() && isActive)
        {
            GameObject enemy = Instantiate(enemyPrefab);
            SetEnemyPosition();
            enemy.transform.position = enemyPosition;
        }

    }

    private void SetEnemyPosition()
    {
        enemyPosition = new Vector3(((int)(Random.Range(transform.position.x - 20f, transform.position.x - 5))), 1.5f, 0);
    }

    private bool generateEnemy()
    {
        if(Time.time > nextEnemy)
        {
            nextEnemy = Time.time + spawnRatio;
            return true;
        }
        return false;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            isActive = true;
            bossQuote.Play();

        }

    }
}