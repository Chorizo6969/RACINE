using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements.Experimental;

public class CheckIfInGround : MonoBehaviour
{
    public bool IsInGround;

    [SerializeField] private string _allowedTag;
    [SerializeField] private List<string> _prohibedTags;
    [SerializeField] private List<Collider> _hitColliders;

    private void OnTriggerEnter(Collider other)
    {
        _hitColliders.Add(other);
        IsInGround = CheckTag();

    }

    private void OnTriggerExit(Collider other)
    {
        _hitColliders.Remove(other);
        IsInGround = CheckTag();
    }

    bool CheckTag()
    {
        bool allow = false;
        foreach (Collider collider in _hitColliders)
        {
            foreach (string tag in _prohibedTags)
            {
                if (collider.CompareTag(tag)) return false;
            }

            if (collider.CompareTag(_allowedTag)) allow = true;
        }
        return allow;
    }

    private void OnDisable()
    {
        _hitColliders.Clear();
    }
}