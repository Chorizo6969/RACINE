using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;

public class HumanNameTempo : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _jobName;

    private async UniTask Start()
    {
        await UniTask.Delay(1000);
        _jobName.text = this.gameObject.GetComponent<Job>().CurrentJob.JobName.ToString();
    }
}
