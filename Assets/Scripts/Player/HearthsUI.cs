using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HearthsUI : MonoBehaviour
{

    public Sprite[] hearthSprites;

    public Image hearthUI;

    public PlayerHealth playerHP;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        hearthUI.sprite = hearthSprites[playerHP.currentHealth];
	}
}
