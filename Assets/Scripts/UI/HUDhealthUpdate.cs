using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDhealthUpdate : MonoBehaviour
{

    public Sprite[] HearthSprites;

    public Image HeartUI;

    private PlayerHealth playerHealth;

    // Use this for initialization
    void Start ()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
	}
	
	// Update is called once per frame
	void Update ()
    {


       // HeartUI.sprite = HearthSprites[playerHealth.currentHealth];
	}
}
