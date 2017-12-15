using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        InputPause();
    }

    void InputPause()
    {
        if(Input.GetButtonDown("Cancel")) Debug.Log("Pause game");
    }


}
