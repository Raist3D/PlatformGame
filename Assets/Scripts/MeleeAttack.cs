using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    public float damage;

    public float knockBack;
    public Vector3 halfSize;

    public float attackRate;
    public float nextMelee;

    int attackableMask;

    public Animator anim;


    PlayerBehaviour playerBh;


    // Use this for initialization
    void Start ()
    {
        attackableMask = LayerMask.GetMask("Attackable");
        //anim = transform.root.GetComponent<Animator>();
        playerBh = transform.root.GetComponent<PlayerBehaviour>();
        nextMelee = 0f;

    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        float attack = Input.GetAxis("Fire1");

        if (attack > 0 && nextMelee < Time.time)
        {
            anim.SetTrigger("meleeAttack");
            nextMelee = Time.time + attackRate;

            //deal damage
            Collider[] attacked = Physics.OverlapBox(transform.position, halfSize, Quaternion.identity, attackableMask);
        }
		
	}
}
