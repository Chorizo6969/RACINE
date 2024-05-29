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

    public static HumanSound instance;

    private void Awake()
    {
        instance = this;
    }

    public void Verification(GameObject human)
    {
        if (human.layer == 8)
        {
            int sound = Random.Range(0, _aqua.Count);
            _source.PlayOneShot(_aqua[sound]);
        }
        else if (human.layer == 9)
        {
            int sound = Random.Range(0, _buchron.Count);
            _source.PlayOneShot(_buchron[sound]);
        }
        else if (human.layer == 10)
        {
            int sound = Random.Range(0, _mineur.Count);
            _source.PlayOneShot(_mineur[sound]);
        }
    }
}
