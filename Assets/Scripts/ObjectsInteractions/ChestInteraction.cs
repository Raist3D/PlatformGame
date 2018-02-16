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

    public Transform Fx;

    Animator anim;

    public AudioClip chestFx;


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
                var effect = Instantiate(Fx, new Vector3 (transform.position.x, transform.position.y + 1, transform.position.z), transform.rotation);
                Destroy(effect.gameObject, 2);

                Destroy(gameObject);
                if(drop) Instantiate(dropItem, new Vector3(transform.localPosition.x, transform.localPosition.y + 1, transform.localPosition.z), transform.localRotation);

                AudioSource.PlayClipAtPoint(chestFx, new Vector3(transform.position.x, transform.position.y, transform.position.z - 31.6f));

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
