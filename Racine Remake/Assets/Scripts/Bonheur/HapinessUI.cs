using TMPro;
using UnityEngine;

public class HapinessUI : MonoBehaviour
{
    [Header("SceneReferences")]
    [SerializeField] private CoolSlider _happinessBar;
    [SerializeField] private TextMeshProUGUI _happinessText;

    public void Setup(float MaxHealthValue, float MinHealthValue, float CurrenthealthValue)
    {
        _happinessBar.MaxValue = MaxHealthValue;
        _happinessBar.MinValue = MinHealthValue;
        _happinessText.text = CurrenthealthValue.ToString();
        UpdateLifebar(0, CurrenthealthValue);

    }

    private void UpdateLifebar(float delta, float newValue)
    {
        _happinessBar.Value = newValue;
    }
}
