using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMusic : MonoBehaviour
{
    public AudioClip music;
    public AudioSource audioSource;

    public void OnClick()
    {
        audioSource.clip = music;
        audioSource.Play();
    }
}