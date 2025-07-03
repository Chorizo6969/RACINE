using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Ce scirpt va stocker la personalit� de l'humain plante et ajouter le script de cette derni�re.
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
        //AttributeComportement.AddComportementHuman(_personality.ComponentName, this.gameObject); //Ajout� le bon script / comportement
    }

}
