using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NamesGenerator : MonoBehaviour
{
    [field: SerializeField]
    public List<string> _arrayNameMasc { get; set; } = new List<string>();

    [field: SerializeField]
    public List<string> _arrayAdjectifMasc { get; set; } = new List<string>();

    [field: SerializeField]
    public List<string> _arrayNameFem { get; set; } = new List<string>();

    [field: SerializeField]
    public List<string> _arrayAdjectifFem { get; set; } = new List<string>();

    public void _randomName()
    {
        int randomGender = Random.Range(1, 3);
        if (randomGender == 1 )
        {
            int randomName = Random.Range(0, _arrayNameMasc.Count);
            string NameMasc = _arrayNameMasc[randomName];
            _arrayNameMasc.Remove(_arrayNameMasc[randomName]);
            int randomAdjectif = Random.Range(0, _arrayAdjectifMasc.Count);
            string AdjectifMasc = _arrayAdjectifMasc[randomAdjectif];
            Debug.Log(NameMasc + " " + AdjectifMasc);
        }
        else
        {
            int randomName = Random.Range(0, _arrayNameFem.Count);
            string NameF = _arrayNameFem[randomName];
            _arrayNameFem.Remove(_arrayNameFem[randomName]);
            int randomAdjectif = Random.Range(0, _arrayAdjectifFem.Count);
            string AdjectifFem = _arrayAdjectifFem[randomAdjectif];
            Debug.Log(NameF + " " + AdjectifFem);
        }
    }
}
