using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Dialogue : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI text;

    [SerializeField]
    private string[] lines;

    [SerializeField]
    private float TextSpeed;

    //[SerializeField]
    //private Animation _anim;

    private int index;

    void Start()
    {
        text.text = string.Empty;
        StartDialogue();
    }

    public void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLines());
    }

    IEnumerator TypeLines()
    {
        StartCoroutine(Accept());
        foreach (char c in lines[index].ToCharArray())
        {
            text.text += c;
            yield return new WaitForSeconds(TextSpeed);
        }

    }

    IEnumerator Accept()
    {
        yield return new WaitForSeconds(3);
        //StopAllCoroutines();
        //text.text = lines[index];
        NextLines();
    }

    public void NextLines()
    {
        index++;
        text.text = string.Empty;
        StartCoroutine(TypeLines());
    }
}
