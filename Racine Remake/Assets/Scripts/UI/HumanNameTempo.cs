using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;

public class HumanNameTempo : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _jobName;
    [SerializeField] private TextMeshProUGUI _personalityName;
    [SerializeField] private HumanPlants _humanRef;

    private async void Start()
    {
        await UniTask.Delay(1000);
        _jobName.text = this._humanRef.HumanJob.CurrentJob.JobName.ToString();
        _personalityName.text = this._humanRef.HumanPersonality.HumanPersonalityRef.PersonalityName.ToString();
        _personalityName.color = Random.ColorHSV();
    }
}
