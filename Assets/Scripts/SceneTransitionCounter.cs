﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class SceneTransitionCounter : MonoBehaviour
{
    Fading fading;
    // Use this for initialization
    IEnumerator Start()
    {

        yield return new WaitForSeconds(4);
        SceneManager.LoadScene("menuScene");


    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
            SceneManager.LoadScene("menuScene");
    }
}