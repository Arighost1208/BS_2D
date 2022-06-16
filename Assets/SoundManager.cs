using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static AudioSource[] _srcs;

    private void Awake()
    {
        _srcs = GetComponents<AudioSource>();
    }

    public static void PlayClip(AudioClip clip, int source = 0)
    {
        PlayClip(clip, 1f, source);
    }

    public static void PlayClip(AudioClip clip, float volume, int source = 0)
    {
        if (clip == null) return;
        _srcs[source].volume = volume;
        _srcs[source].PlayOneShot(clip);
    }
}
