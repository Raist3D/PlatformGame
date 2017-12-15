using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{

    bool pause;


	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(Input.GetButtonDown("Cancel")) pause = !pause; 

        if(pause)  Time.timeScale = 0; 

        if(!pause)  Time.timeScale = 1; 
    }
}
