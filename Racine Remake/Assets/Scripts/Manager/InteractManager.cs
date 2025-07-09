using Cysharp.Threading.Tasks;
using UnityEngine;

public class InteractManager : MonoBehaviour
{
    [SerializeField] private LayerMask _targetLayer;

    private void Start()
    {
        VerifClick().Forget();
    }

    private async UniTaskVoid VerifClick()
    {
        while (true)
        {
            await UniTask.WaitUntil(() => Input.GetMouseButtonDown(0));

            print("clic");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, _targetLayer))
            {
                print("clic2");
                GameObject target = hit.collider.gameObject;
                await Happiness.Instance.BuffHappiness(5);
                Destroy(target);
            }

            await UniTask.Yield();
        }
    }
}
