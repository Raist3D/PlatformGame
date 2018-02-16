using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class potionFx : MonoBehaviour
{

    public Transform Fx;



    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy" || other.tag == "Ground")
        {
            var effect = Instantiate(Fx, transform.position, transform.rotation);

            Destroy(effect.gameObject, 2);
            //Destroy(gameObject);

        }
    }

}
