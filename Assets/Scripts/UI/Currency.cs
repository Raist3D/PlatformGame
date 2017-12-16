using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Currency : MonoBehaviour
{

    public int gold;
    GameObject HUD;

    void Start()
    {
        HUD = GameObject.Find("Currency");
    }
    void Update()
    {
        HUD.GetComponent<Text>().text = gold.ToString();
        if(gold < 0)
        {
            gold = 0;
        }
    }
}