using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{

    public bool gravity;

    [Header("Physics")]
    public float jumpForce;
    public Rigidbody rb;
    private float axis;
    public float speedWalk;
    private bool jump;
    private bool doubleJump;

    [Header("Dash")]
    private bool canDash;
    private bool isDashing;
    private float timeDash;
    public float dashSpeed;
    private float currentDashTime;

  /*  [Header("Weapon Skill Charge")]
    private bool canCharge;
    private bool isCharging;
    private float timeCharge;
    public float chargeSpeed;
    private float currentChargeTime;
    bool canDealDamage;
    public float chargeDamage;
    public Vector2 directionForce;
    public BoxCollider chargeTrigger;
    */
    [Header("Graphics")]
    public Animator anim;
    public bool facingRight;
    public Transform meshTransform;
    public SkinnedMeshRenderer meshRenderer;
    public MeshRenderer swordRenderer;

    [Header("GroundChecker")]
    public Transform groundChecker;
    public Vector3 halfSize;
    public LayerMask groundMask;
    public bool isGrounded;

    [Header("Wall Checker")]
    public Transform wallChecker;
    public Vector3 wallHalfSize;
    public LayerMask wallMask;
    public bool isTouchingWall;

    [Header("Ceiling Checker")]
    public Transform ceilingChecker;
    public Vector3 ceilingHalfSize;
    public LayerMask ceilingMask;
    public bool isTouchingCeiling;

    [Header("Stun")]
    public bool stunDamaged;
    public float stunTime;
    public float stunFinish;
    public bool immune;
    public float immuneTime;

    [Header("Potion Throw")]
    public int potionAmmo;
    public bool canThrowPotion;
    public float potionThrowRatio;
    public float timePotionThrow;
    public Vector3 potionPosition;

    public GameObject potion;

    public AudioSource jumpFx;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //chargeTrigger = gameObject.GetComponentInChildren<BoxCollider>();
        facingRight = true;
        canDash = true;
       // canCharge = true;
        gravity = true;
        canThrowPotion = true;
        
        // anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        axis = Input.GetAxis("Horizontal") * speedWalk;

        if (isGrounded)
        {
            //canCharge = true;
            jump = false;
            doubleJump = false;
        }

        //Potion Throw
        if (!stunDamaged && Input.GetButtonDown("Fire2"))
        {
            if(!canThrowPotion && Time.time > timePotionThrow)
                canThrowPotion = true;

            if(canThrowPotion)
            {
                GameObject poti = Instantiate(potion);
                poti.transform.position = this.transform.position + potionPosition;

                if(facingRight)
                    poti.GetComponent<Rigidbody>().velocity = new Vector3(20, 25, 0);
                else
                    poti.GetComponent<Rigidbody>().velocity = new Vector3(-20, 25, 0);

                canThrowPotion = false;
                timePotionThrow = Time.time + 1;
            }
        }

        if(Input.GetButtonDown("Jump"))
        {
            if (isGrounded)
            {
                rb.velocity = new Vector3(rb.velocity.x, 0, 0);
                rb.AddForce(0, jumpForce, 0, ForceMode.Impulse);
                jumpFx.Play();

                canDash = true;
                if (!jump) jump = true;
            }


            else
            {
                if (!doubleJump)
                {
                    rb.velocity = new Vector3(rb.velocity.x, 0, 0);
                    rb.AddForce(0, jumpForce, 0, ForceMode.Impulse);
                    jumpFx.Play();

                    doubleJump = true;
                    jump = true;
                    anim.SetTrigger("doubleJump");
                }
            }
        }

        //else if (Input.GetKeyUp(KeyCode.LeftShift)) speed = speedWalk;

        //controller.move(moveDirection * Time.deltaTime);

        if (axis > 0 && !facingRight) Flip();
        else if (axis < 0 && facingRight) Flip();
        
    //Animation

    anim.SetBool("isGrounded", isGrounded);
    anim.SetFloat("speed", Mathf.Abs(axis));
}

    void FixedUpdate()
    {
        //Detect ground
        Collider[] hitColliders = Physics.OverlapBox(groundChecker.position, halfSize, Quaternion.identity, groundMask);
        if (hitColliders.Length != 0) isGrounded = true;
        else isGrounded = false;

        //Detect walls
        hitColliders = Physics.OverlapBox(wallChecker.position, wallHalfSize, Quaternion.identity, wallMask);
        if (hitColliders.Length != 0) isTouchingWall = true;
        else isTouchingWall = false;

        //Detect ceiling
        hitColliders = Physics.OverlapBox(ceilingChecker.position, ceilingHalfSize, Quaternion.identity, ceilingMask);
        if (hitColliders.Length != 0) isTouchingCeiling = true;
        else isTouchingCeiling = false;

        if(stunDamaged)
        {
            if(stunFinish < Time.time)
                stunDamaged = false;
        }

        if(immune)
        {
            meshRenderer.enabled = !meshRenderer.enabled;
            swordRenderer.enabled = !swordRenderer.enabled;

            if(stunFinish + immuneTime < Time.time)
            {
                immune = false;

                meshRenderer.enabled = true;
                swordRenderer.enabled = true;
            }

        }


        /*bool charge = Input.GetButtonDown("Fire3");
        if(charge)
        {
            if(charge && canCharge && isGrounded)
            {
                if(facingRight)
                    rb.velocity = new Vector3(rb.velocity.x + chargeSpeed, 0, 0);
                //rb.transform.position = new Vector3(rb.position.x + 1, rb.position.y, 0);
                else
                    rb.velocity = new Vector3(rb.velocity.x - chargeSpeed, 0, 0);
                //rb.transform.position = new Vector3(rb.position.x - 1, rb.position.y, 0);

                canCharge = false;
                isCharging = true;
                timeCharge = 1f;
                gravity = false;
            }

            if(isCharging)
            {
                timeCharge -= 0.1f;

                if(timeCharge <= 0.0f)
                {
                    isCharging = false;
                    gravity = true;
                    rb.velocity = Vector3.zero;
                }

            }
        }*/

        bool dash = Input.GetButtonDown("Dash");

        if(dash && !isGrounded && canDash)
        {
            if (facingRight)
                rb.velocity = new Vector3(rb.velocity.x + dashSpeed, 0, 0);
                //rb.transform.position = new Vector3(rb.position.x + 1, rb.position.y, 0);
            else
                rb.velocity = new Vector3(rb.velocity.x - dashSpeed, 0, 0);
                //rb.transform.position = new Vector3(rb.position.x - 1, rb.position.y, 0);

            canDash = false;
            isDashing = true;
            timeDash = 1f;
            gravity = false;
        }

        if(isDashing)
        {
            timeDash -= 0.1f;

            if (timeDash <= 0.0f)
            {
                isDashing = false;
                gravity = true;
                rb.velocity = Vector3.zero;
            }
                
        }

        //MOVE PLAYER
        //if (isGrounded) //NO MOVERSE EN EL AIRE
        //{
        if(!isDashing && !isTouchingWall && !stunDamaged) //&& !isCharging
            rb.velocity = new Vector3(axis, rb.velocity.y, 0);
            //rb.AddForce(axis, 0, 0); MODO HIELO 
        //}
        if (!isGrounded && gravity)
        {
            rb.AddForce(0, -98, 0);
        }

    }

    void Flip()
    {
        Vector3 newScale = meshTransform.localScale;
        newScale.x *= -1;
        meshTransform.localScale = newScale;

        facingRight = !facingRight;
    }

    /*void OnTriggerEnter(Collider chargeTrigger)
    {
        if(chargeTrigger.tag == "Enemy" && isCharging)
        {
            enemyHealth doDamage = chargeTrigger.GetComponent<enemyHealth>();
            //doDamage.AddDamage(damage);
            doDamage.DamageFX(transform.position, transform.localEulerAngles);
            canDealDamage = false;
            DamageEnemy(chargeTrigger.gameObject);


        }
    }
    void DamageEnemy(GameObject who)
    {
        who.GetComponent<enemyHealth>().AddDamage(chargeDamage);

        Vector3 dir = directionForce;
        if(who.transform.position.x < this.transform.position.x) dir.x *= -1;

        Rigidbody rb = who.GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;

        rb.AddForce(dir, ForceMode.Impulse);
    }*/



    void OnDrawGizmos()
    {
        //Draw overlap boxes
        Gizmos.color = Color.magenta;
        if (groundChecker != null) Gizmos.DrawWireCube(groundChecker.position, halfSize * 2);

        Gizmos.color = Color.blue;
        if (wallChecker != null) Gizmos.DrawWireCube(wallChecker.position, wallHalfSize * 2);

        Gizmos.color = Color.yellow;
        if (ceilingChecker != null) Gizmos.DrawWireCube(ceilingChecker.position, ceilingHalfSize * 2);
    }

    public void Stun(Vector3 knock)
    {
        stunDamaged = true;
        immune = true;
        stunFinish = Time.time + stunTime;
        rb.velocity = Vector3.zero;
        rb.AddForce(knock, ForceMode.Impulse);
    }
}
