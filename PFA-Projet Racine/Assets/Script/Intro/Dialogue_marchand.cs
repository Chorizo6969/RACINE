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
    private GameObject panel;


    [SerializeField]
    private List<AudioClip> clips;

    [SerializeField]
    private AudioSource _source;

    public bool canWright = true;

    private int index;

    public static Dialoguemarchand instance;


    private void Awake()
    {
        instance = this;
    }

    public void StartDialogue()
    {
        StopCoroutine(TypeLines());
        text.text = string.Empty;
        index = 0;
        int sound = Random.Range(0, clips.Count);
        _source.PlayOneShot(clips[sound]);
        canWright = true;
        StartCoroutine(TypeLines());
    }

    IEnumerator TypeLines()
    {
        int _chooselines = Random.Range(0, lines.Length);
        index = _chooselines;
        foreach (char c in lines[index].ToCharArray())
        {
            if (canWright)
            {
                text.text += c;
                yield return new WaitForSeconds(TextSpeed);
            }
            else
            {
                StopAllCoroutines();
            }
        }
    }

    public void Desactive()
    {
        canWright = false; 
        StopCoroutine(TypeLines());
        text.text = string.Empty;
    }
}
