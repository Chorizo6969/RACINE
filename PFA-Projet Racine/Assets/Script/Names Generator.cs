using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script qui va permettre de choisir de façon random les noms des humains plantes
/// </summary>
public class NamesGenerator : MonoBehaviour
{
    /// <summary>
    /// Liste des prénoms masculin.
    /// </summary>
    [field: SerializeField]
    public List<string> _arrayNameMasc { get; set; } = new List<string>();

    /// <summary>
    /// Liste des adjectifs masculin
    /// </summary>
    [field: SerializeField]
    public List<string> _arrayAdjectifMasc { get; set; } = new List<string>();

    /// <summary>
    /// Liste des prénoms féminin
    /// </summary>
    [field: SerializeField]
    public List<string> _arrayNameFem { get; set; } = new List<string>();

    /// <summary>
    /// Liste des adjectifs féminin
    /// </summary>
    [field: SerializeField]
    public List<string> _arrayAdjectifFem { get; set; } = new List<string>();

    public static NamesGenerator Instance;

    public string Nom;
    public string Adjectif;

    private void Awake()
    {
        Instance = this;
    }

    /// <summary>
    /// Fonction qui choisi le genre de l'humain plante ainsi que son nom
    /// </summary>
    public void RandomName()
    {
        int randomGender = Random.Range(1, 3);
        if (randomGender == 1 )
        {
            int randomName = Random.Range(0, _arrayNameMasc.Count);
            string NameMasc = _arrayNameMasc[randomName];
            Nom = NameMasc;
            _arrayNameMasc.Remove(_arrayNameMasc[randomName]);
            int randomAdjectif = Random.Range(0, _arrayAdjectifMasc.Count);
            string AdjectifMasc = _arrayAdjectifMasc[randomAdjectif];
            Adjectif = AdjectifMasc;
            Debug.Log(NameMasc + " " + AdjectifMasc);
        }
        else
        {
            int randomName = Random.Range(0, _arrayNameFem.Count);
            string NameF = _arrayNameFem[randomName];
            Nom = NameF;
            _arrayNameFem.Remove(_arrayNameFem[randomName]);
            int randomAdjectif = Random.Range(0, _arrayAdjectifFem.Count);
            string AdjectifFem = _arrayAdjectifFem[randomAdjectif];
            Adjectif = AdjectifFem;
            Debug.Log(NameF + " " + AdjectifFem);
        }
    }
}
