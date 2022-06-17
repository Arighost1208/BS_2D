using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowBounce : MonoBehaviour
{
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

   // [SerializeField] AudioClip audioPost;
    public void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "soccer ball")
        {
            audioSource.Play();
        }
        
    }

}