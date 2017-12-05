using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public enum State { Default, Dead, God }
    public State state;


    [Header("Physics")]
    public float jumpForce;
    public Rigidbody rb;
    private float axis;
    private float speed;
    public float speedWalk;
    public float speedRun;
    private bool jump;
    private bool doubleJump;

    public Vector3 moveDirection;
    public float maxDashTime = 1.0f;
    public float dashSpeed;
    public float dashStoppingSpeed = 0.1f;

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
        speed = speedWalk;
        currentDashTime = maxDashTime;
       // anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        axis = Input.GetAxis("Horizontal") * speed;


        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded)
            {
                if (!jump) jump = true;
            }
            else
            {
                if (!doubleJump)
                {
                    doubleJump = true;
                    jump = true;
                    //anim.SetTrigger("doubleJump");
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            currentDashTime = 0.0f;
        }
        if (currentDashTime < maxDashTime)
        {
            moveDirection = new Vector3(dashSpeed, 0, 0);
            currentDashTime += dashStoppingSpeed;
        }

        //else if (Input.GetKeyUp(KeyCode.LeftShift)) speed = speedWalk;

        else
        {
            moveDirection = Vector3.zero;
        }
        //controller.move(moveDirection * Time.deltaTime);


        if (axis > 0 && !facingRight) Flip();
        else if (axis < 0 && facingRight) Flip();

    //Animation

    //anim.SetBool("isGrounded", isGrounded);
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

        if (jump)
        {
            rb.velocity = new Vector3(rb.velocity.x, 0, 0);
            rb.AddForce(0, jumpForce, 0, ForceMode.Impulse);

            jump = false;
        }

        if (isGrounded)
        {
            if (doubleJump) doubleJump = false;
        }

        if (isTouchingWall)
        {
            if (facingRight && axis > 0) axis = 0;
            else if (!facingRight && axis < 0) axis = 0;
        }

        rb.velocity = new Vector3(axis, rb.velocity.y, 0);
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
