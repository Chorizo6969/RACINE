using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanSound : MonoBehaviour
{
    [SerializeField]
    private List<AudioClip> _aqua;

    [SerializeField]
    private List<AudioClip> _buchron;

    [SerializeField]
    private List<AudioClip> _mineur;

    [SerializeField]
    private AudioSource _source;

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
            int sound = Random.Range(0, _aqua.Count);
            _source.PlayOneShot(_aqua[sound]);
            StartCoroutine(AutorizeSound());
        }
        else if (human.layer == 9 && !_isPlaying)
        {
            int sound = Random.Range(0, _buchron.Count);
            _source.PlayOneShot(_buchron[sound]);
            StartCoroutine(AutorizeSound());
        }
        else if (human.layer == 10 && !_isPlaying)
        {
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
