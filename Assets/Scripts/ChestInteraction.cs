using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestInteraction : MonoBehaviour
{

    public bool drop;
    public GameObject dropItem;

    Animator anim;


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
        if(other.tag == "Player" && Input.GetButtonDown("Interact"))
        {
            Destroy(this.gameObject);
            if(drop) Instantiate(dropItem, transform.position, transform.rotation);
            anim.SetTrigger("openChest");
        }

    }
}
