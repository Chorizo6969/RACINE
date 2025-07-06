using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script qui ajuste l'UI des humains plantes (Late Update). 
/// </summary>
public class HealthBarManager : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;

    private List<RectTransform> _rectTransformRef = new();

    [SerializeField] private Quaternion _rotationLock;

    public static HealthBarManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void RegisterCanvas(RectTransform rect)
    {
        if (!_rectTransformRef.Contains(rect))
            _rectTransformRef.Add(rect);
    }

    private void LateUpdate()
    {
        foreach (RectTransform rect in _rectTransformRef)
        {
            rect.rotation = _rotationLock;
        }
    }

}
