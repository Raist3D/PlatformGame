using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public Transform meshTransform;

    //detection
    public float detectionTime;
    float startRun;
    bool firstDetection;

    //mov. options
    public float runSpeed;
    public float walkspeed;
    public bool facingRight = true;

    float movSpeed;
    bool running;

    Rigidbody rb;
    Animator anim;
    Transform detectedPlayer;

    bool detected;

	// Use this for initialization
	void Start ()
    {
        rb = GetComponentInParent<Rigidbody>();
        anim = GetComponentInParent<Animator>();

        running = false;
        detected = false;
        firstDetection = false;
        movSpeed = walkspeed;

        if(Random.Range(0, 10) > 5) Flip();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
		if (detected)
        {
            if(detectedPlayer.position.x < transform.position.x && facingRight) Flip();
            else if(detectedPlayer.position.x > transform.position.x && !facingRight) Flip();

            if(!firstDetection)
            {
                startRun = Time.time + detectionTime;
                firstDetection = true;

            }
        }
        if(detected && !facingRight) rb.velocity = new Vector3((movSpeed * -1), rb.velocity.y, 0);
        else if (detected && facingRight) rb.velocity = new Vector3((movSpeed), rb.velocity.y, 0);

        if (!running && detected)
        {
            if (startRun < Time.time)
            {
                movSpeed = runSpeed;
                anim.SetTrigger("run");
                running = true;
            }
        }

    }

    void OnTriggerEnter (Collider other)
    {
        if (other.tag == "Player" && !detected)
        {
            detected = true;
            detectedPlayer = other.transform;
            anim.SetBool("detected", detected);

            if(detectedPlayer.position.x < transform.position.x && facingRight) Flip();
            else if(detectedPlayer.position.x > transform.position.x && !facingRight) Flip();

        }
    }

    void OnTriggerExit (Collider other)
    {
        if(other.tag == "Player")
        {
            firstDetection = false;

            if(running)
            {
                anim.SetTrigger("run");
                movSpeed = walkspeed;
                running = false;

            }
        }
    }

    void Flip ()
    {
        Vector3 newScale = meshTransform.localScale;
        newScale.x *= -1;
        meshTransform.localScale = newScale;

        facingRight = !facingRight;

    }
}
