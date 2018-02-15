using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundPickUp : MonoBehaviour
{
    public Renderer rend;

    public void Start()
    {
        rend.enabled = true;
    }

    public void SoundDestroyDelay()
    {
        AudioSource audio = GetComponent<AudioSource>();
        rend.enabled = false;
        Destroy(gameObject, audio.clip.length);
    }
}