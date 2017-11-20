using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*public class PlayerBehaviour : MonoBehaviour
{
    [Header("Physics")]
    public float jumpForce;
    public Rigidbody rb;
    private float axis;
    private float speed;
    public float speedWalk;
    public float speedRun;
    private bool jump;
    private bool doubleJump;


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

        if (Input.GetKeyDown(KeyCode.LeftShift)) speed = speedRun;
        else if (Input.GetKeyUp(KeyCode.LeftShift)) speed = speedWalk;

        if (axis > 0 && !facingRight) Flip();
        else if (axis < 0 && facingRight) Flip();

        //Animation

       // anim.SetBool("isGrounded", isGrounded);
       //anim.SetFloat("speed", Mathf.Abs(axis));
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
*/

    [RequireComponent(typeof(PlayerCollisions))]
public class PlayerBehaviour : MonoBehaviour
{
    public enum State { Default, Dead, God }
    public State state;

    [Header("State")]
    public bool canMove = true;
    public bool canJump = true;
    public bool running = false;
    public bool isFacingRight = true;
    public bool isJumping = false;
    [Header("Physics")]
    public Rigidbody rb;
    public PlayerCollisions collisions;
    [Header("Speed properties")]
    public float walkSpeed = 2;
    public float runSpeed = 3;
    public float movementSpeed;
    [Header("Force properties")]
    public float jumpWalkForce;
    public float jumpRunForce;
    public float jumpForce;
    [Header("Movement")]
    public Vector2 axis;
    public float horizontalSpeed;
    //[Header("Transforms")]
    //public Transform flipTransform;
    [Header("Graphics")]
    //public SpriteRenderer rend;
    private Animator anim;

    void Start()
    {
        collisions = GetComponent<PlayerCollisions>();
        rb = GetComponent<Rigidbody>();

        collisions.MyStart();

        isFacingRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case State.Default:
                DefaultUpdate();
                break;
            case State.Dead:
                break;
            case State.God:
                break;
            default:
                break;
        }
    }

    void DefaultUpdate()
    {
        //Calcule el movimiento en horizontal
        HorizontalMovement();
        //Saltar

        //Anmaciones
        /*anim.SetBool("isGrounded", collisions.isGrounded);
        anim.SetFloat("speedX", Mathf.Abs(rb.velocity.x));
        anim.SetFloat("speedY", Mathf.Abs(rb.velocity.y));*/
    }

    private void FixedUpdate()
    {
        collisions.MyFixedUpdate();

        if (isJumping)
        {
            isJumping = false;
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(Vector2.up * jumpForce, ForceMode.Impulse);
        }
        //Aplicaremos el movimiento
        rb.velocity = new Vector2(horizontalSpeed, rb.velocity.y);
    }

    void HorizontalMovement()
    {
        if (!canMove)
        {
            horizontalSpeed = 0;
            return;
        }

        rb.constraints = RigidbodyConstraints.FreezeRotation;

        if (-0.1f < axis.x && axis.x < 0.1f)
        {
            horizontalSpeed = 0;
            rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezeRotation;
            return;
        }

        if (collisions.isTouchingWall)
        {
            if ((isFacingRight && axis.x > 0.1f) || (!isFacingRight && axis.x < -0.1f))
            {
                horizontalSpeed = 0;
                return;
            }
        }

        if (isFacingRight && axis.x < -0.1f) Flip();
        if (!isFacingRight && axis.x > 0.1f) Flip();

        if (running) movementSpeed = runSpeed;
        else movementSpeed = walkSpeed;

        horizontalSpeed = axis.x * movementSpeed;
    }
    void VerticalMovement()
    {
        /*
         * bool lookingUp
         * bool lookingDown
         * bool crouch
         */
    }
    void Jump(float force)
    {
        jumpForce = force;
        isJumping = true;
    }
    void Flip()
    {
        //rend.flipX = !rend.flipX;
        isFacingRight = !isFacingRight;
        collisions.Flip(isFacingRight);
    }


    #region Public functions
    public void SetAxis(Vector2 inputAxis)
    {
        axis = inputAxis;
    }
    public void JumpStart()
    {
        if (!canJump) return;

        if (state == State.Default)
        {
            if (collisions.isGrounded)
            {
                if (running) Jump(jumpRunForce);
                else Jump(jumpWalkForce);
            }
        }

    }
    public void Damage(int hit)
    {

    }
    #endregion
}
