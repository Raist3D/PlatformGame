using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShot : MonoBehaviour
{
    public float shotRatio;
    public GameObject fireBall;
    private float nextShot;
    public Transform playerTransform;
    private float distX;
    private float distY;

    public bool isActive;
    public BoxCollider trigger;

    public AudioSource bossAS;

    public AudioClip fireballCastFx;

    // Use this for initialization
    void Start ()
    {
        nextShot = Time.time + shotRatio;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (isActive)
        {
            if(Time.time > nextShot)
            {
                bossAS.PlayOneShot(fireballCastFx);

                GameObject shot = Instantiate(fireBall);
                shot.transform.position = new Vector3(transform.position.x - 3, transform.position.y + 3, 1);
                distX = transform.position.x - playerTransform.position.x;
                distY = (transform.position.y - playerTransform.position.y) + 1;
                shot.GetComponent<Rigidbody>().velocity = new Vector3(-10, -10 * (distY / distX), 0);
                nextShot = Time.time + shotRatio;
            }
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            isActive = true;
        }

    }

}
