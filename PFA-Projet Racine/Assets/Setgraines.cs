using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Setgraines : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _graines;

    [SerializeField]
    private int nombreGraines = 0;

    public void AddGraines()
    {
        nombreGraines += 1;
        _graines.text = nombreGraines.ToString();
    }

    public void DeleteGraines(TextMeshProUGUI graines)
    {
        nombreGraines -= 1;
        graines.text = nombreGraines.ToString();
    }
}
