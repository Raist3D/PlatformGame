using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CercanyChecker : MonoBehaviour
{
    public bool detected;


	// Use this for initialization
	void Start ()
    {
        detected = false;
		
	}


    void OnTriggerEnter (Collider other)
    {
        if(other.tag == "Player")
        {
            detected = true;
        }

    }

    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            detected = false;
        }
    }

}
