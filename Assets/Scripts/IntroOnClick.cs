using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;


public class IntroOnClick : MonoBehaviour
{

    public GameObject timeLine;
    public GameObject textIntro;
    public GameObject skipText;
    public Animator animator;
    public AudioSource audioSourceMenu;
    public AudioSource audioSourceIntro;
    public bool volume;
    public bool scene;
    public bool skip = false;

    void Start()
    {

    }

    void Update()
    {
        if(volume)
        {
            audioSourceIntro.volume += Time.deltaTime * 0.2f;

            audioSourceMenu.volume -= Time.deltaTime * 0.3f;
        }

        if(scene)
        {

            StartCoroutine(ChangeScene());
            StartCoroutine(StartIntro());
            StartCoroutine(VolumeOut());

        }
        if(skip)
        {
            if(Input.GetButtonDown("Cancel"))
            {
                SceneManager.LoadScene("Stage_01");

            }

        }

    }
    public void StartAnim()
    {
        audioSourceIntro.Play();

        textIntro.gameObject.SetActive(true);

        animator.enabled = true;
        volume = true;
        scene = true;

    }

    IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(19.5f);

        SceneManager.LoadScene("Stage_01");
    }

    IEnumerator StartIntro()
    {
        yield return new WaitForSeconds(8);


        PlayableDirector pd = timeLine.GetComponent<PlayableDirector>();

        if(Input.GetButtonDown("Cancel"))
        {
            skip = true;

            skipText.gameObject.SetActive(true);

        }

        pd.Play();

    }

    IEnumerator VolumeOut()
    {
        yield return new WaitForSeconds(14);

        audioSourceIntro.Stop();

    }




}
