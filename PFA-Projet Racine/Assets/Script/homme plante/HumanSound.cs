using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class HumanSound : MonoBehaviour
{
    public List<AudioClip> _aqua;

    public List<AudioClip> _buchron;

    public List<AudioClip> _mineur;

    public AudioSource _source;

    private bool _isPlaying;

    public static HumanSound instance;

    private void Awake()
    {
        instance = this;
    }

    public void Verification(GameObject human)
    {
        if (human.layer == 8 && !_isPlaying)
        {
            human.GetComponent<IA>().VFX.Play();
            int sound = Random.Range(0, _aqua.Count);
            _source.PlayOneShot(_aqua[sound]);
            StartCoroutine(AutorizeSound());
        }
        else if (human.layer == 9 && !_isPlaying)
        {
            human.GetComponent<IA>().VFX.Play();
            int sound = Random.Range(0, _buchron.Count);
            _source.PlayOneShot(_buchron[sound]);
            StartCoroutine(AutorizeSound());
        }
        else if (human.layer == 10 && !_isPlaying)
        {
            human.GetComponent<IA>().VFX.Play();
            int sound = Random.Range(0, _mineur.Count);
            _source.PlayOneShot(_mineur[sound]);
            StartCoroutine(AutorizeSound());
        }

    }

    IEnumerator AutorizeSound()
    {
        _isPlaying = true;
        yield return new WaitForSeconds(1);
        _isPlaying = false;
    }
}
