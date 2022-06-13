using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundButton : MonoBehaviour
{

    public AudioSource font;
    public AudioClip clip;

   
    void Start()
    {
        font.clip = clip;
    }

    public void PlayClip()
    {
        font.Play();
    }

   
}
