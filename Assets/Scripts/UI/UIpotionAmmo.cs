using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIpotionAmmo : MonoBehaviour
{

    public int potionAmmo;
    GameObject HUD;

    void Start()
    {
        HUD = GameObject.Find("PotionCount");
    }
    void Update()
    {
        HUD.GetComponent<Text>().text = potionAmmo.ToString();
        if(potionAmmo > 5)
        {
            potionAmmo = 5;
        }
    }


}