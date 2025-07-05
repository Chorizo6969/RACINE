using System.Collections.Generic;
using UnityEngine;

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

    public void RegisterEntity(RectTransform rect)
    {
        if (!_rectTransformRef.Contains(rect))
            _rectTransformRef.Add(rect);
    }

    void LateUpdate()
    {
        foreach (RectTransform rect in _rectTransformRef)
        {
            rect.rotation = _rotationLock;
        }
    }

}
