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
            ShowHUH(human);
        }
        else if (human.layer == 9 && !_isPlaying)
        {
            int sound = Random.Range(0, _buchron.Count);
            _source.PlayOneShot(_buchron[sound]);
            StartCoroutine(AutorizeSound());
            ShowHUH(human);
        }
        else if (human.layer == 10 && !_isPlaying)
        {
            int sound = Random.Range(0, _mineur.Count);
            _source.PlayOneShot(_mineur[sound]);
            StartCoroutine(AutorizeSound());
            ShowHUH(human);
        }

    }

    public void ShowHUH(GameObject human)
    {
        Debug.Log("TAAAAAAAAAAAAAAAA GROOOOOOOOOOOOOOOOOOOSSE MEEEEEEEEEEEEEEERE LAAAAAAAAAAAAAAAAAAAAA PUUUUUUUUUUUUUUUUUUUUUTE");
        human.GetComponent<IA>().ImageHUH.GetComponent<Animator>().SetBool("Question", true);
        StartCoroutine(AttendImageHUH(human));
    }

    IEnumerator AttendImageHUH(GameObject human)
    {
        yield return new WaitForSeconds(human.GetComponent<IA>().HUHAnim.length);
        human.GetComponent<IA>().ImageHUH.GetComponent<Animator>().SetBool("Question", false);
    }

    IEnumerator AutorizeSound()
    {
        _isPlaying = true;
        yield return new WaitForSeconds(1);
        _isPlaying = false;
    }
}
