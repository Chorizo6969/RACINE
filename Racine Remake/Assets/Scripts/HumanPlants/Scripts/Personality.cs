using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static HumanEnum;

/// <summary>
/// Ce scirpt va stocker la personalité de l'humain plante et ajouter le script de cette dernière.
/// </summary>
public class Personality : MonoBehaviour
{
    private HumanPersonalitySO _humanPersonality;
    [SerializeField] private List<HumanPersonalitySO> _allPersonality = new();
    [SerializeField] private Stats _stats;

    public event Action OnStatsReady;

    private void Start() 
    {
        ChooseAPersonality();
    }

    private async void ChooseAPersonality()
    {
        int indexChoose = UnityEngine.Random.Range(0, _allPersonality.Count - 1);

        _humanPersonality = _allPersonality[indexChoose];
        await _stats.Setup(_humanPersonality);

        SetupSomePersonality();

        OnStatsReady.Invoke();
    }

    private async void SetupSomePersonality()
    {
        if (_humanPersonality.PersonalityName is HumanPersonality.BonVivant) { await Happiness.Instance.BuffHappiness(_stats.HappinessFlat); } //Attribution bonheur
        else if (_humanPersonality.PersonalityName is HumanPersonality.MoteurFeuillu or HumanPersonality.Surpoids) { GetComponent<NavMeshAgent>().speed = _stats.SpeedHuman; } //attribution speed
        else if (_humanPersonality.PersonalityName is HumanPersonality.Crapophage or HumanPersonality.FanDeCrotte) { GetComponent<PoopDetector>().enabled = true; }
        else if (_humanPersonality.PersonalityName is HumanPersonality.Narcoleptique) { GetComponent<Narcoleptique>().enabled = true; }
    }
}
