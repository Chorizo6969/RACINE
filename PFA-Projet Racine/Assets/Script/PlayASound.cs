using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayASound : MonoBehaviour
{
    public static PlayASound Instance;
    public AudioClip sound;

    private void Awake()
    {
        Instance = this;
    }

    public void PlaySound()
    {
        gameObject.GetComponent<AudioSource>().clip = sound;
        gameObject.GetComponent<AudioSource>().Play();
    }
}