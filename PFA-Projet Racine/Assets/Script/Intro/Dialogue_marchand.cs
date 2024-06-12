using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class Dialoguemarchand : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI text;

    [SerializeField]
    private string[] lines;

    [SerializeField]
    private float TextSpeed;

    [SerializeField]
    private List<AudioClip> clips;

    [SerializeField]
    private AudioSource _source;

    private int index;

    public void StartDialogue()
    {
        text.text = string.Empty;
        index = 0;
        //int sound = Random.Range(0, clips.Count);
        //_source.PlayOneShot(clips[sound]);
        StartCoroutine(TypeLines());
    }

    IEnumerator TypeLines()
    {
        int _chooselines = Random.Range(0, lines.Length);
        index = _chooselines;
        foreach (char c in lines[index].ToCharArray())
        {
            text.text += c;
            yield return new WaitForSeconds(TextSpeed);
        }

    }
}
