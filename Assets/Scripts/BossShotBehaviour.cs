using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShotBehaviour : MonoBehaviour
{
    public int damage;
    public Vector3 directionForce;


    // Use this for initialization
    void Start ()
    {
        Vector3 dir = directionForce;

    }

    // Update is called once per frame
    void Update ()
    {
		
	}

    void OnTriggerEnter(Collider other)
    {

        if(other.tag == "Player")
        {
            if(other.transform.position.x < this.transform.position.x) directionForce.x *= -1;

            other.GetComponent<PlayerHealth>().AddDamage(damage, directionForce);

            Destroy(this.gameObject);
        }
        else if(other.tag == "Ground")
        {
            Destroy(this.gameObject);
        }
    }
}
