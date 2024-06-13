using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Juxebox : MonoBehaviour
{
    [SerializeField]
    private AudioSource _AudioSource;

    [SerializeField]
    private AudioClip _audio1;

    [SerializeField]
    private Image pochetteAlbum;

    [SerializeField]
    private Sprite PlayButton;

    [SerializeField]
    private Sprite _pause;

    [SerializeField]
    private Image PauseButton;

    [SerializeField]
    private List<Image> Imagebouton;

    [SerializeField]
    private List<Sprite> NotedeMusique;

    [SerializeField]
    private List<Sprite> spriteAlbum;

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
            PauseButton.sprite = _pause;
            _isPlaying = false;
        }
        else
        {
            _AudioSource.UnPause();
            PauseButton.sprite = PlayButton;
            _isPlaying = true;
        }
    }

    public void Retry()
    {
        _AudioSource.Play();
    }

    public void PlaySong1()
    {
        Imagebouton[0].sprite = NotedeMusique[0];
        Imagebouton[1].sprite = PlayButton;
        Imagebouton[2].sprite = PlayButton;
        Imagebouton[3].sprite = PlayButton;
        Imagebouton[4].sprite = PlayButton;
        pochetteAlbum.sprite = spriteAlbum[0];
        _AudioSource.clip = _audio1;
        _AudioSource.Play();
    }

    public void PlaySong2()
    {
        Imagebouton[1].sprite = NotedeMusique[1];
        Imagebouton[0].sprite = PlayButton;
        Imagebouton[2].sprite = PlayButton;
        Imagebouton[3].sprite = PlayButton;
        Imagebouton[4].sprite = PlayButton;
        pochetteAlbum.sprite = spriteAlbum[1];
        _AudioSource.clip = _audio2;
        _AudioSource.Play();
    }

    public void PlaySong3()
    {
        Imagebouton[2].sprite = NotedeMusique[2];
        Imagebouton[1].sprite = PlayButton;
        Imagebouton[0].sprite = PlayButton;
        Imagebouton[3].sprite = PlayButton;
        Imagebouton[4].sprite = PlayButton;
        pochetteAlbum.sprite = spriteAlbum[2];
        _AudioSource.clip = _audio3;
        _AudioSource.Play();
    }

    public void PlaySong4()
    {
        Imagebouton[3].sprite = NotedeMusique[3];
        Imagebouton[1].sprite = PlayButton;
        Imagebouton[2].sprite = PlayButton;
        Imagebouton[0].sprite = PlayButton;
        Imagebouton[4].sprite = PlayButton;
        pochetteAlbum.sprite = spriteAlbum[3];
        _AudioSource.clip = _audio4;
        _AudioSource.Play();
    }

    public void PlaySong5()
    {
        Imagebouton[4].sprite = NotedeMusique[4];
        Imagebouton[1].sprite = PlayButton;
        Imagebouton[2].sprite = PlayButton;
        Imagebouton[3].sprite = PlayButton;
        Imagebouton[0].sprite = PlayButton;
        pochetteAlbum.sprite = spriteAlbum[4];
        _AudioSource.clip = _audio5;
        _AudioSource.Play();
    }
}
