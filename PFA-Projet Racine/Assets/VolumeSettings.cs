using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField]
    private Slider musicSlider;
    [SerializeField]
    private Slider SFXSlider;
    [SerializeField]
    private AudioMixer myMixer;

    private void Start()
    {
        if (PlayerPrefs.HasKey("musiqueVolume"))
        {
            LoadVolume();
        }
        else
        {
            SetMusicVolume();
            SetSFXVolume();
        }
    }

    public void SetMusicVolume()
    {
        float volume = musicSlider.value;
        myMixer.SetFloat("Musique", Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("musiqueVolume", volume);
    }

    public void SetSFXVolume()
    {
        float volume = SFXSlider.value;
        myMixer.SetFloat("SFX", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("musiqueSFX", volume);
    }

    private void LoadVolume()
    {
        musicSlider.value = PlayerPrefs.GetFloat("musiqueVolume");
        SFXSlider.value = PlayerPrefs.GetFloat("musiqueSFX");
        SetMusicVolume();
        SetSFXVolume();
    }
}
