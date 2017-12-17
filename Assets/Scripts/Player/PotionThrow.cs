using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionThrow : MonoBehaviour
{
    public float timeThrow;
    public GameObject potion;

    float nextThrow;


	// Use this for initialization
	void Awake ()
    {
        nextThrow = 0f;
	}
	
	// Update is called once per frame
	void Update ()
    {
        PlayerBehaviour playerBh = transform.root.GetComponent<PlayerBehaviour>();

        if(Input.GetAxisRaw("Fire2") > 0 && nextThrow < Time.time)
        {
            nextThrow = Time.time + timeThrow;

            Vector3 pos;

            if(playerBh.facingRight)
            {
                pos = new Vector3(0, -90, 0);
            }
            else pos = new Vector3(0, 90, 0);

            Instantiate(potion, transform.position, Quaternion.Euler(pos));
        }
		
	}
}
