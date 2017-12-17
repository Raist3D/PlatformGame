using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyItems : MonoBehaviour
{

    MeleeAttack meleeAtk;


    // Use this for initialization
    void Start ()
    {
        meleeAtk = gameObject.GetComponent<MeleeAttack>();

    }

    // Update is called once per frame
    void Update ()
    {

	}

    void OnTriggerEnter(Collider meleeAtk)
    {

        if(meleeAtk.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }



}
