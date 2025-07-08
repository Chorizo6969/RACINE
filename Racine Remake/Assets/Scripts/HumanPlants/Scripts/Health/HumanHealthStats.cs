using Cysharp.Threading.Tasks;
using UnityEngine;

/// <summary>
/// Gestion de la vie d'un humain plante (ApplyDamage, ApllyHealth, Die)
/// </summary>
public class HumanHealthStats : MonoBehaviour
{
    [SerializeField] private float currentHealth;
    [SerializeField] private float maxHealth;
    [SerializeField] private HumanHealthUI _humanHealthUIRef;

    private void Start()
    {
        Setup(100, 100); //Stats par défaut
    }

    public async void Setup(float maxHP, float startHP)
    {
        this.maxHealth = maxHP;
        currentHealth = startHP;

        await ApplyHealth(0);
        _humanHealthUIRef.Setup(maxHealth, 0, currentHealth);
    }

    public async UniTask ApplyDamage(float damage)
    {
        damage = Mathf.Max(damage, 0);
        await ApplyHealth(-damage);
    }

    public async UniTask ApplyHealth(float delta)
    {
        currentHealth += delta;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        if (currentHealth <= 0)
            await Die();
    }

    public async UniTask Die()// à faire
    {
        print("mort");
        await UniTask.Yield();
    }
}
