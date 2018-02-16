using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{

    bool pause;
    public Canvas pauseMenu;

    public AudioSource pauseAS;

    public AudioClip pauseFx;

	// Use this for initialization
	void Start ()
    {
        //pauseMenu.gameObject.SetActive(false);

    }
	
	// Update is called once per frame
	void Update ()
    {
        if(Input.GetButtonDown("Cancel")) pause = !pause;

        if(pause)
        {

            Time.timeScale = 0;
            pauseMenu.gameObject.SetActive(true);
        }

        if(!pause )  
        {

            Time.timeScale = 1;
            pauseMenu.gameObject.SetActive(false);
        }
    }

    public void ResumeGame()
    {
            Time.timeScale = 1;
            pauseMenu.gameObject.SetActive(false);
    }


}
