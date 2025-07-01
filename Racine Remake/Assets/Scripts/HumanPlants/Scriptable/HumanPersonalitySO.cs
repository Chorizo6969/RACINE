using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "NewHumanPersonality", menuName = "Human/Personality")]
public class HumanPersonalitySO : ScriptableObject
{
    [Header("Base Job")]
    [SerializeField] private HumanEnum.HumanPersonality _personalityName;
    [SerializeField] private string _description;
    [SerializeField] private string _componentName;

    //Pour le code (lecture seule)
    public HumanEnum.HumanPersonality PersonalityName => _personalityName;
    public string Description => _description;
    public string ComponentName => _componentName;
}