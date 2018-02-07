using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ChestInteraction : MonoBehaviour
{

    public bool drop;
    public GameObject dropItem;
    public GameObject checker;
    public bool playerNear;
    public Image interactionButton;

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
            interactionButton.gameObject.SetActive(true);

            if(Input.GetButtonDown("Interact"))
            {
                Destroy(gameObject);
                if(drop) Instantiate(dropItem, transform.localPosition, transform.localRotation);
            }
        }
        else
        {
            interactionButton.gameObject.SetActive(false);
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
