using Cysharp.Threading.Tasks;
using UnityEngine;

public class Happiness : MonoBehaviour
{
    [SerializeField] private float currentHappiness;
    [SerializeField] private HapinessUI _hapinessUIRef;

    public static Happiness Instance;
    private void Awake() { Instance = this; }

    private void Start()
    {
        Setup(100); //Stats par défaut
    }

    public async void Setup(float startHP)
    {
        currentHappiness = startHP;

        await BuffHappiness(0);
        _hapinessUIRef.Setup(100, 0, currentHappiness);
    }

    public async UniTask ReduceHappiness(float damage)
    {
        damage = Mathf.Max(damage, 0);
        await BuffHappiness(-damage);
    }

    public async UniTask BuffHappiness(float delta)
    {
        currentHappiness += delta;
        await UniTask.Yield();
    }
}
