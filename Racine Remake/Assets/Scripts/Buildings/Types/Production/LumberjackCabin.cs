using System.Collections;
using UnityEngine;

public class LumberjackCabin : WorkBase
{
    [SerializeField] private float _treeDetectionRadius;
    [SerializeField] private LayerMask _cellLayer;
    private Collider[] _results;

    private void Start()
    {
        //StartCoroutine(CheckTreeCoroutine());
    }

    private IEnumerator CheckTreeCoroutine()
    {
        while (true)
        {
            int hitCount = Physics.OverlapSphereNonAlloc(transform.position, _treeDetectionRadius, _results, _cellLayer);
            for (int i = 0; i < hitCount; i++)
            {
                if (_results[i].TryGetComponent(out Cell cellComponent))
                {
                    print(cellComponent.transform.position);
                }
            }
            yield return new WaitForSeconds(0.5f);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(this.transform.position, _treeDetectionRadius);
    }
}
