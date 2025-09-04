using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LumberjackCabin : WorkBase
{
    [SerializeField] private float _treeDetectionRadius;
    [SerializeField] private LayerMask _cellLayer;
    private Collider[] _results;
    [SerializeField] private List<ProtoTree> _trees = new();

    private void Start()
    {
        StartCoroutine(CheckTreeCoroutine());
    }

    private IEnumerator CheckTreeCoroutine()
    {
        _results = new Collider[500];
        while (true)
        {
            int hitCount = Physics.OverlapSphereNonAlloc(transform.position, _treeDetectionRadius, _results, _cellLayer);
            for (int i = 0; i < hitCount; i++)
            {
                if (!_results[i].TryGetComponent(out Cell cell)) continue;
                if (!cell.Building) continue;
                if (!cell.Building.TryGetComponent(out ProtoTree tree)) continue;
                if (_trees.Contains(tree)) continue;
               
                _trees.Add(tree);
            }
            yield return new WaitForSeconds(1f);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(this.transform.position, _treeDetectionRadius);
        Gizmos.color = Color.magenta;
        foreach (var tree in _trees)
        {
            if (!tree) return;
            Ray ray = new Ray(tree.transform.position, transform.up * 6);
            Gizmos.DrawRay(ray);
        }
    }
}
