using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{

    /*public GameObject gameTitle;
    public GameObject playButton;
    public GameObject optionsButton;
    public GameObject exitButton;
    public GameObject presENTERButton;

    bool enterPressed;

    void Start()
    {
        gameTitle.transform.position = new Vector3(Screen.width/2, Screen.height + 150, 0);

        playButton.SetActive(false);
        optionsButton.SetActive(false);
        exitButton.SetActive(false);
        presENTERButton.SetActive(false);

        enterPressed = false;

    }

    void FixedUpdate()
    {
        if(gameTitle.transform.position.y >= Screen.height / 4*3)
            gameTitle.transform.position = new Vector3(gameTitle.transform.position.x, gameTitle.transform.position.y - 3, 0);

        else
        {
            if(!enterPressed && Input.GetButtonDown("Submit"))
                enterPressed = true;

            if (enterPressed)
            {
                presENTERButton.SetActive(false);
                playButton.SetActive(true);
                optionsButton.SetActive(true);
                exitButton.SetActive(true);

            }
            else
            {
                presENTERButton.SetActive(true);
            }

        }
    }*/


    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadScene(int buildIndex)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(buildIndex);


    }

    public void LoadScene(string sceneName)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneName);
    }
}
