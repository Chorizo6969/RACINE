using UnityEngine;
using static HumanEnum;

[CreateAssetMenu(fileName = "NewHumanPersonality", menuName = "Human/Personality")]
public class HumanPersonalitySO : ScriptableObject
{
    [Header("Base Job")]
    [SerializeField] private HumanPersonality _personalityName;
    [SerializeField] private string _description;
    [SerializeField] private HumanPersonalityEffect _effect;
    [SerializeField] private HumanPersonalityCalcule _calcule;
    [SerializeField] private float _value;

    public HumanPersonality PersonalityName => _personalityName;
    public string Description => _description;
    public HumanPersonalityEffect Effect => _effect;
    public HumanPersonalityCalcule Calcule => _calcule;
    public float Value => _value;

}