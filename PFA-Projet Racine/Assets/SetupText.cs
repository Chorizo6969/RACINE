using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SetupText : MonoBehaviour
{
    [SerializeField]
    private List<TextMeshProUGUI> _text = new(); //buche,eau,pierre

    public static SetupText Instance;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        UpdateMaxText();
    }

    public void UpdateMaxText()
    {
        if (IncrementHuman.instance._countBucheron == IncrementHuman.instance._maxBucheron) { _text[0].color = Color.red; }
        else { _text[0].color = Color.white; }

        _text[0].text = IncrementHuman.instance._countBucheron.ToString() + "/" + IncrementHuman.instance._maxBucheron.ToString();

        if (IncrementHuman.instance._countAquaman == IncrementHuman.instance._maxAquaman) { _text[1].color = Color.red; }
        else { _text[1].color = Color.white; }

        _text[1].text = IncrementHuman.instance._countAquaman.ToString() + "/" + IncrementHuman.instance._maxAquaman.ToString();

        if (IncrementHuman.instance._countStoneMan == IncrementHuman.instance._maxStoneMan) { _text[2].color = Color.red; }
        else { _text[2].color = Color.white; }

        _text[2].text = IncrementHuman.instance._countStoneMan.ToString() + "/" + IncrementHuman.instance._maxStoneMan.ToString();
    }
}
