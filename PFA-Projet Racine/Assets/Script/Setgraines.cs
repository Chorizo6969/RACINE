using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Setgraines : MonoBehaviour
{
    public TextMeshProUGUI _graines;

    [SerializeField]
    private int _woodCost;

    [SerializeField]
    private int _stoneCost;

    [SerializeField]
    private int _waterCost;

    public int nombreGraines = 0;

    public void AddGraines()
    {
        if (RessourceManager.Instance.CheckIfCanBuild(_woodCost,_stoneCost ,_waterCost))
        {
            nombreGraines += 1;
            _graines.text = nombreGraines.ToString();
        }
    }

    public void DeleteGraines(TextMeshProUGUI graines)
    {
        nombreGraines -= 1;
        graines.text = nombreGraines.ToString();
    }
}