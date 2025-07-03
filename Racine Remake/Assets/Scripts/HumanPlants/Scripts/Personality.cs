using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Ce scirpt va stocker la personalité de l'humain plante et ajouter le script de cette dernière.
/// </summary>
public class Personality : MonoBehaviour
{
    [SerializeField] private HumanPersonalitySO _humanPersonality;
    [SerializeField] private List<HumanPersonalitySO> _allPersonality = new();

    void Start() { ChooseAPersonality(); }

    private void ChooseAPersonality()
    {
        int indexChoose = Random.Range(0, _allPersonality.Count - 1);
        _humanPersonality = _allPersonality[indexChoose];
        //AttributeComportement.AddComportementHuman(_personality.ComponentName, this.gameObject); //Ajouté le bon script / comportement
    }

}
