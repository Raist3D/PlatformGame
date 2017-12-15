using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public enum State { Default, Dead, God }
    public State state;

    public bool gravity;

    [Header("Physics")]
    public float jumpForce;
    public Rigidbody rb;
    private float axis;
    public float speedWalk;
    private bool jump;
    private bool doubleJump;

    private bool canDash;
    private bool isDashing;
    private float timeDash;
    public float dashSpeed;

    private float currentDashTime;

    [Header("Graphics")]
    public Animator anim;
    public bool facingRight;
    public Transform meshTransform;

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

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        facingRight = true;
        canDash = true;
        gravity = true;
        // anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        axis = Input.GetAxis("Horizontal") * speedWalk;

        if (isGrounded)
        {
            jump = false;
            doubleJump = false;
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded)
            {
                rb.velocity = new Vector3(rb.velocity.x, 0, 0);
                rb.AddForce(0, jumpForce, 0, ForceMode.Impulse);

                canDash = true;
                if (!jump) jump = true;
            }

            else
            {
                if (!doubleJump)
                {
                    rb.velocity = new Vector3(rb.velocity.x, 0, 0);
                    rb.AddForce(0, jumpForce, 0, ForceMode.Impulse);

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

        bool dash = Input.GetButtonDown("Dash");

        if (dash && !isGrounded && canDash)
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

        //if (isGrounded) //NO MOVERSE EN EL AIRE
        //{
        if(!isDashing && !isTouchingWall)
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
}
