using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTutoriel : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI text;

    public List<string> lines;

    [SerializeField]
    private float TextSpeed;

    [SerializeField]
    private Image _image;

    private int index;
    public bool isfinish = false;

    public static DialogueTutoriel instance;

    private void Awake()
    {
        instance = this;
    }

    public void OnEnable()
    {
        Debug.Log("grgseg");
        StartDialogue();
    }

    public void StartDialogue()
    {
        isfinish = false;
        _image.gameObject.SetActive(true);
        text.text = string.Empty;
        index = 0;
        _ = TypeLines();
    }

    async Task TypeLines()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            text.text += c;
            await Task.Delay((int)(TextSpeed*1000));
        }
        await Accept();

    }

    private async Task Accept()
    {
        while (!(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))) await Task.Yield();
            StopAllCoroutines();
            text.text = lines[index];
            NextLines();
        
    }

    public void NextLines()
    {
        index++;
        text.text = string.Empty;
        if (index == lines.Count)
        {
            gameObject.SetActive(false);
            _image.gameObject.SetActive(false);
            isfinish = true;
            return;
        }
        _ = TypeLines();
    }
}
