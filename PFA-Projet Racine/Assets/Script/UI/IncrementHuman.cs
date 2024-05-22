using TMPro;
using UnityEngine;

public class IncrementHuman : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _textHuman;

    private int _count = 0;

    public static IncrementHuman instance;

    public void Awake()
    {
        instance = this;
    }

    public void Stonks()
    {
        _count++;
        _textHuman.text = _count.ToString();
    }

    public void Death(int death)
    {
        _count -= death;
        _textHuman.text = _count.ToString();
    }
}
