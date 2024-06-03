using System.Collections.Generic;
using UnityEngine;

public class playerAnimationEventReceiver : MonoBehaviour
{

    public AudioSource audioSource;
    //public void Canard() => Coin1.Invoke();
    public List<AudioClip> sons = new();
    void PlaySound()
    {
        //audioSource.clip = Son1;
        audioSource.clip = sons[Random.Range(0, sons.Count)];
        audioSource.Play();
    }
}