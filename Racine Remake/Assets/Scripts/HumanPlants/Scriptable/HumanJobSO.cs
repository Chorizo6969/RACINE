using UnityEngine;

[CreateAssetMenu(fileName = "NewHumanJob", menuName = "Human/Human Job")]
public class HumanJobSO : ScriptableObject
{
    [Header("Base Job")]
    [SerializeField] private HumanEnum.HumanJobs _jobName;
    [SerializeField] private Mesh _mesh;
    [SerializeField] private string _description;

    [Header("Stat Modifiers")]
    [SerializeField] private float _healthModifier = 0f;
    [SerializeField] private float _speedModifier = 0f; //A voir...

    public HumanEnum.HumanJobs JobName => _jobName;
    public Mesh Mesh => _mesh;
    public string Description => _description;
    public float HealthModifier => _healthModifier;
    public float SpeedModifier => _speedModifier;
}