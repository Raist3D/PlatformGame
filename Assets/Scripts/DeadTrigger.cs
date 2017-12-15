﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("KillPlayer");
            Application.LoadLevel(Application.loadedLevelName);
        }
    }
}
