using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    public float damage;

    public float knockBack;
    float knockBackRadius;

    public Vector3 halfSize;
    public Vector2 directionForce;

    public float attackRate;
    public float nextMelee;

    bool canDealDamage;

    int attackableMask;

    public Animator anim;


    PlayerBehaviour playerBh;
    BoxCollider weaponTrigger;
    public ParticleSystem meleeSplashPS;
    public AudioSource swordAS;

    public AudioClip boxDestroyFx;
    public AudioClip enemyHitFx;


    // Use this for initialization
    void Start ()
    {
        attackableMask = LayerMask.GetMask("Attackable");
        //anim = transform.root.GetComponent<Animator>();
        playerBh = transform.root.GetComponent<PlayerBehaviour>();
        nextMelee = 0f;
        weaponTrigger = gameObject.GetComponent<BoxCollider>();
        canDealDamage = false;
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        //float attack = Input.GetAxis("Fire1");
        bool attack = Input.GetButtonDown("Fire1");

        if(nextMelee < Time.time)
        {
            canDealDamage = false;

            if(attack)
            {
                nextMelee = Time.time + attackRate;
                anim.SetTrigger("meleeAttack");
                swordAS.Play();
                canDealDamage = true;
            }
        }
	}

    void OnTriggerEnter(Collider weaponTrigger)
    {
        if(weaponTrigger.tag == "Enemy" && canDealDamage)
        {
            swordAS.PlayOneShot(enemyHitFx);

            //enemyHealth doDamage = weaponTrigger.GetComponent<enemyHealth>();
            //doDamage.AddDamage(damage);
            //doDamage.DamageFX(transform.position, transform.localEulerAngles);
            canDealDamage = false;
            DamageEnemy(weaponTrigger.gameObject);
            meleeSplashPS.Play();
        }

        if(weaponTrigger.tag == "Interactuable" && canDealDamage)
        {
            Debug.Log("Destroy interactuable");
            swordAS.PlayOneShot(boxDestroyFx);

            DestroyItems doDamage = weaponTrigger.GetComponent<DestroyItems>();
            doDamage.AddDamage(damage);
            //doDamage.DamageFX(transform.position, transform.localEulerAngles);
            canDealDamage = false;
            meleeSplashPS.Play();
        }

    }

    void DamageEnemy(GameObject who)
    {
        who.GetComponent<enemyHealth>().AddDamage(damage);

        Vector3 dir = directionForce;
        if(who.transform.position.x < this.transform.position.x) dir.x *= -1;

        Rigidbody rb = who.GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;

        rb.AddForce(dir, ForceMode.Impulse);
    }


}

//deal damage
//Collider[] attacked = Physics.OverlapSphere(transform.position, knockBackRadius, attackableMask);
//Collider[] attacked = Physics.OverlapBox(transform.position, halfSize, Quaternion.identity, attackableMask);


/*int i = 0;
while (i < attacked.Length)
{
    if (attacked[i].tag == "Enemy")
    {
        enemyHealth doDamage = attacked[i].GetComponent<enemyHealth>();
        doDamage.AddDamage(damage);
        doDamage.DamageFX(transform.position, transform.localEulerAngles);
    }
    i++;

}*/

