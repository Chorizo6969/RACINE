using Cysharp.Threading.Tasks;
using System.Reflection;
using UnityEngine;
using static HumanEnum;

/// <summary>
/// Classe majeur, elle observe le SO personnality et change les statistiques de l'humain plante !
/// </summary>
public class Stats : MonoBehaviour
{
    #region Variable
    [Range(-1, 1)] public float EfficiencyWorking; //Vitesse de travail
    [Range(-1, 1)] public float WiningRessourcesRatio; // Ration de ressource
    [Range(0, 1)] public float FightingProba; //Kéké
    [Range(0, 1)] public float SickProba; // Porba malade
    [Range(0, 1)] public float ForgetRessourcesProba; // Proba d'oublié les ressources
    public float SpeedHuman; //Vitesse des humains
    public float PoopSpeed; // Vitesse de caca
    public float TimeBeforeOrder; //Mou du bulbe
    public bool IsScared; //Fuit les chèvres
    public bool IsNarcoleptique; //Dodo n'importe quand
    public bool CleanPoop; //Rammase les caca
    public bool FixeCaca; //Fixe un caca
    public float BuffAudioValue; //CriePourRien
    public float HappinessFlat; //Jauge de bonheur

    public bool IsHome = true;
    public bool IsSick;
    public bool IsFakeSick;
    #endregion

    public async UniTask Setup(HumanPersonalitySO _personality) //Utilise le principe de reflection (Un enum (HumanPersonalityEffect) possède la même écriture que les variables au dessus.)
    {
        string fieldName = _personality.Effect.ToString();
        FieldInfo field = typeof(Stats).GetField(fieldName);

        if (field == null) //Donc on va regarder le field de l'enum et voir si il correspond à mes variables
        {
            Debug.LogWarning($"Champ '{fieldName}' introuvable dans Stats connard");
            return;
        }

        if(_personality.Calcule == HumanPersonalityCalcule.Bool)
        {
            if (_personality.Value == 0)
                field.SetValue(this, false);
            else
                field.SetValue(this, true);
        }
        else { field.SetValue(this, _personality.Value); }

        await UniTask.Yield();
             
    }

}