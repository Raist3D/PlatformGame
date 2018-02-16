using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PickUpLoot : MonoBehaviour
{

    Currency currentGold;
    public AudioClip coinFx;

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
            Destroy(gameObject, 2);
            AudioSource.PlayClipAtPoint(coinFx, new Vector3 (transform.position.x, transform.position.y, transform.position.z - 31.6f));

        }
    }
}