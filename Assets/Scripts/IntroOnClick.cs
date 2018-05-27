using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;


public class IntroOnClick : MonoBehaviour
{

    public GameObject timeLine;
    public Animator animator;
    public AudioSource audioSource;
    public bool volume;
    public bool scene;

    void Start()
    {

    }

    void Update()
    {
        if(volume)
        {
            audioSource.volume -= Time.deltaTime * 0.2f;
        }

        if(scene)
        {
            StartCoroutine(ChangeScene());
        }

    }
    public void StartAnim()
    {
        PlayableDirector pd = timeLine.GetComponent<PlayableDirector>();

        pd.Play();

        animator.enabled = true;
        volume = true;
        scene = true;


    }

    IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(10);

        SceneManager.LoadScene("Stage_01");
    }

}
