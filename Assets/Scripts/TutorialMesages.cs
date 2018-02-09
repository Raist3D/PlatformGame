using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TutorialMesages : MonoBehaviour
{

    public GameObject checker;
    public bool playerNear;
    public Text tutorialMessage;

    Animator anim;


    // Use this for initialization
    void Start()
    {
        playerNear = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(checker.GetComponent<CercanyChecker>().detected)
        {
            tutorialMessage.gameObject.SetActive(true);

        }
        else
        {
            tutorialMessage.gameObject.SetActive(false);
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            playerNear = true;
        }

    }

    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            playerNear = false;
        }
    }
}
