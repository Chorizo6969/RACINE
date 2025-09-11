using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LumberjackCabin : WorkBase
{
    [SerializeField] private float _treeDetectionRadius;
    [SerializeField] private LayerMask _cellLayer;
    private List<ProtoTree> _trees = new();
    private Collider[] _results;

    private void Start()
    {
        CheckTree();
    }

    // Appeler cette coroutine quand on ouvre l'ui pour sélectionner quel arbre bucheronner. / ou quand bûcheron termine de couper un arbre et va en chercher un nouveau
    
    /// <summary>
    /// Retourne la liste des arbres qui sont dans le rayon de la cabane de bûcheron.
    /// </summary>
    /// <returns></returns>
    private List<ProtoTree> CheckTree()
    {
        _results = new Collider[500];

        int hitCount = Physics.OverlapSphereNonAlloc(transform.position, _treeDetectionRadius, _results, _cellLayer);
        for (int i = 0; i < hitCount; i++)
        {
            // On vérifie que le collider soit bien une cellule, que la cellule ne soit pas vide, que le bâtiment soit bien un arbre et que l'arbre ne soit pas déjà dans la liste. 
            if (!_results[i].TryGetComponent(out Cell cell)) continue;
            if (!cell.Building) continue;
            if (!cell.Building.TryGetComponent(out ProtoTree tree)) continue;
            if (_trees.Contains(tree)) continue;

            _trees.Add(tree);
        }

        return _trees;
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
