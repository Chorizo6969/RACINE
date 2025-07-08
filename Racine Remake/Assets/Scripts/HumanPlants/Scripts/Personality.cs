using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Ce scirpt va stocker la personalité de l'humain plante et ajouter le script de cette dernière.
/// </summary>
public class Personality : MonoBehaviour
{
    private HumanPersonalitySO _humanPersonality;
    [SerializeField] private List<HumanPersonalitySO> _allPersonality = new();
    public Stats _stats;

    private void Start() 
    {
        ChooseAPersonality();
    }

    private void ChooseAPersonality()
    {
        int indexChoose = Random.Range(0, _allPersonality.Count - 1);
        _humanPersonality = _allPersonality[indexChoose];
        _stats.Setup(_humanPersonality);
    }
}
