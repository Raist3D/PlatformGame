using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodMode : MonoBehaviour
{

    public bool godMode;
    public PlayerBehaviour playerBhScript;
    public Rigidbody rb;
    public Collider playerCollider;

    public float speed;

    //PlayerBehaviour playerBhScript;

    // Use this for initialization
    void Start ()
    {
        godMode = false;
        playerBhScript = GetComponent<PlayerBehaviour>();
        rb = GetComponent<Rigidbody>();
        playerCollider = GetComponent<Collider>();

    }

    // Update is called once per frame
    void Update ()
    {
        if(Input.GetButtonDown("EnableGodMode"))
        {
            godMode = true;

            playerBhScript.enabled = !playerBhScript.enabled;
            playerCollider.enabled = !playerCollider.enabled;
            playerBhScript.enabled = playerBhScript.enabled;


        }

        if(godMode)
        {
            if(Input.GetButtonDown("DisableGodMode"))
            {
                godMode = false;
                playerBhScript.enabled = playerBhScript.isActiveAndEnabled;

            }

            if(Input.GetButton("Horizontal"))
           {
                transform.Translate(speed * Time.deltaTime, 0, 0);

            }

            if(Input.GetButton("MoveLeft"))
           {
               transform.Translate((speed *= -1) * Time.deltaTime, 0, 0);
           }

           if(Input.GetButton("Vertical"))
           {
               transform.Translate(0, speed * Time.deltaTime, 0);

            }

            if(Input.GetButton("MoveDown"))
           {
               transform.Translate(0, (speed *= -1) * Time.deltaTime , 0);

            }






        }
    }
}

