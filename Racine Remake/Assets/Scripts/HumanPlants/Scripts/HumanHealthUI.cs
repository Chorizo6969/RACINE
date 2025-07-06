using UnityEngine;

public class HumanHealthUI : MonoBehaviour
{
    [Header("SceneReferences")]
    [SerializeField] private CoolSlider _lifebar;
    [SerializeField] private RectTransform _canvas;

    private void Start()
    {
        HealthBarManager.Instance.RegisterCanvas(_canvas);
    }

    public void Setup(float MaxHealthValue, float MinHealthValue, float CurrenthealthValue)
    {
        //healthbar
        _lifebar.MaxValue = MaxHealthValue;
        _lifebar.MinValue = MinHealthValue;
        UpdateLifebar(0, CurrenthealthValue);

    }

    private void UpdateLifebar(float delta, float newValue)
    {
        _lifebar.Value = newValue;
    }
}
