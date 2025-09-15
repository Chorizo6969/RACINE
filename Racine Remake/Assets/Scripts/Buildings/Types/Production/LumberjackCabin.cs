using System.Collections.Generic;
using UnityEngine;

public class LumberjackCabin : WorkBase
{
    [SerializeField] private float _treeDetectionRadius;
    [SerializeField] private LayerMask _cellLayer;

    private List<ProtoTree> _trees = new();
    private Collider[] _results;

    public List<ProtoTree> Trees {  get { return _trees; } }

    private void Update()
    {
        GetClosestTree();    
    }

    // Appeler quand on ouvre l'ui pour sélectionner quel arbre bucheronner. / ou quand bûcheron termine de couper un arbre et va en chercher un nouveau

    /// <summary>
    /// Retourne la liste des arbres qui sont dans le rayon de la cabane de bûcheron.
    /// </summary>
    /// <returns></returns>
    private List<ProtoTree> CheckTreeInCabinRadius()
    {
        // formule pour estimer le nombre de cellules dans le rayon (div par l'aire des cells remplacée par * 1.5f comme facteur de sécurité)
        int estimatedColliderCount = Mathf.CeilToInt((Mathf.PI * _treeDetectionRadius * _treeDetectionRadius) * 1.5f);

        _results = new Collider[estimatedColliderCount];

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

    /// <summary>
    /// Retourne l'arbre le plus proche, ou null si aucun n'arbre ne se trouve dans le rayon de détection.
    /// </summary>
    /// <returns></returns>
    public ProtoTree GetClosestTree()
    {
        List<ProtoTree> nearTrees = CheckTreeInCabinRadius();
        
        if (nearTrees.Count == 0) return null;

        // temporary comparative values
        ProtoTree closestTree = nearTrees[0];
        float minDistance = Vector3.Distance(this.transform.position, nearTrees[0].transform.position);

        for(int i = 0; i < nearTrees.Count; i++)
        {
            if (Vector3.Distance(this.transform.position, nearTrees[i].transform.position) < minDistance)
            {
                minDistance = Vector3.Distance(this.transform.position, nearTrees[i].transform.position);
                closestTree = nearTrees[i];
            }
        }

        return closestTree;
    }
}
