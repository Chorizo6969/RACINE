using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Dialoguemarchand : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI text;

    [SerializeField]
    private string[] lines;

    [SerializeField]
    private float TextSpeed;

    private int index;

    public void StartDialogue()
    {
        text.text = string.Empty;
        index = 0;
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
