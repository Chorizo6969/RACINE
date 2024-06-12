using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Juxebox : MonoBehaviour
{
    [SerializeField]
    private AudioSource _AudioSource;

    [SerializeField]
    private AudioClip _audio1;

    [SerializeField] 
    private AudioClip _audio2;

    [SerializeField] 
    private AudioClip _audio3;

    [SerializeField] 
    private AudioClip _audio4;

    [SerializeField]
    private AudioClip _audio5;

    private bool _isPlaying = true;

    public void Pause()
    {
        if (_isPlaying)
        {
            _AudioSource.Pause();
            _isPlaying = false;
        }
        else
        {
            _AudioSource.UnPause();
            _isPlaying = true;
        }
    }

    public void Retry()
    {
        _AudioSource.Play();
    }

    public void PlaySong1()
    {
        _AudioSource.clip = _audio1;
        _AudioSource.Play();
    }

    public void PlaySong2()
    {
        _AudioSource.clip = _audio2;
        _AudioSource.Play();
    }

    public void PlaySong3()
    {
        _AudioSource.clip = _audio3;
        _AudioSource.Play();
    }

    public void PlaySong4()
    {
        _AudioSource.clip = _audio4;
        _AudioSource.Play();
    }

    public void PlaySong5()
    {
        _AudioSource.clip = _audio5;
        _AudioSource.Play();
    }
}
