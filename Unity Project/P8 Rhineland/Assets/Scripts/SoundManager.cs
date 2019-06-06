using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public AudioSource source2d;
    public AudioSource source3d;
    public AudioSource sourceBackground;

    public void Play2DSound(AudioClip clip)
    {
        source2d.PlayOneShot(clip);
    }

    public void Play3DSound(AudioClip clip)
    {
        source2d.PlayOneShot(clip);
    }
}
