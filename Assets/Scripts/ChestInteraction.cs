using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestInteraction : MonoBehaviour
{

    public bool drop;
    public GameObject dropItem;
    public GameObject checker;
    public bool playerNear;

    Animator anim;


    // Use this for initialization
    void Start ()
    {
        playerNear = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(checker.GetComponent<CercanyChecker>().detected)
        {
            

            if (Input.GetButtonDown("Interact"))
            {
                Destroy(gameObject);
            }
        }

	}

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            playerNear = true;
        }

    }

    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            playerNear = false;
        }
    }
}
