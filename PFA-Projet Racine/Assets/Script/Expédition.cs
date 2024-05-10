using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Expédition : MonoBehaviour
{
    public GameObject Ia;
    public TextMeshProUGUI Nom;
    public TextMeshProUGUI Adjectif;

    public void Start()
    {
        Nom.text = Ia.GetComponent<IA>().Nom;
        Adjectif.text = Ia.GetComponent<IA>().Adjectif;
    }
}
