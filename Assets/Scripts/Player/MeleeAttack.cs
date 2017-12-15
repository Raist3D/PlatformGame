using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    public float damage;

    public float knockBack;
    float knockBackRadius;

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
        //float attack = Input.GetAxis("Fire1");
        bool attack = Input.GetButtonDown("Fire1");

        if (attack && nextMelee < Time.time)
        {
            anim.SetTrigger("meleeAttack");
            nextMelee = Time.time + attackRate;

            //deal damage
            Collider[] attacked = Physics.OverlapSphere(transform.position, knockBackRadius, attackableMask);
            //Collider[] attacked = Physics.OverlapBox(transform.position, halfSize, Quaternion.identity, attackableMask);

            int i = 0;
            while (i < attacked.Length)
            {
                if (attacked[i].tag == "Enemy")
                {
                    enemyHealth doDamage = attacked[i].GetComponent<enemyHealth>();
                    doDamage.AddDamage(damage);
                    doDamage.DamageFX(transform.position, transform.localEulerAngles);
                }
                i++;

            }
        }
		
	}
}
