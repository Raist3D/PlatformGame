using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpLoot : MonoBehaviour
{

    Currency currentGold;

    public int addAmount;

    void Start()
    {
        currentGold = GameObject.FindGameObjectWithTag("GameController").GetComponent<Currency>();
    }

    void OnTriggerEnter(Collider obj)
    {
        if(obj.gameObject.tag == "Player")
        {
            currentGold.gold += addAmount;
            Destroy(gameObject);
        }
    }
}