using Cysharp.Threading.Tasks;
using UnityEngine;

/// <summary>
/// Classe temporaire pour tester les interaction
/// </summary>
public class InteractManager : MonoBehaviour
{
    [SerializeField] private LayerMask _poopTargetLayer;
    [SerializeField] private LayerMask _humanLayer;

    private void Start()
    {
        VerifClick().Forget();
    }

    private async UniTask VerifClick()
    {
        while (true)
        {
            await UniTask.WaitUntil(() => Input.GetMouseButtonDown(0));

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, _poopTargetLayer | _humanLayer))
            {
                GameObject target = hit.collider.gameObject;

                if (((1 << target.layer) & _poopTargetLayer) != 0) //Vérifie si le layer est actif sur l'objet
                {
                    await Happiness.Instance.BuffHappiness(5);
                    Destroy(target);                     // TODO: Replace with pooling
                }

                else if (((1 << target.layer) & _humanLayer) != 0)
                {
                    HumanPlants human = target.GetComponent<HumanPlants>();
                    if (human.StatsRef.Asleep)
                    {
                        target.GetComponent<Narcoleptique>()?.StopSleep();
                    }
                }
            }

            await UniTask.Yield();
        }
    }

}
