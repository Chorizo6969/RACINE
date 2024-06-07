using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class Count : MonoBehaviour
{
    public float countDuration = 1;
    TextMeshProUGUI numberText;
    float currentValue = 0, targetValue = 0;
    Coroutine _C2T;
    RectTransform _rectTransform;

    void Awake()
    {
        numberText = GetComponent<TextMeshProUGUI>();
        _rectTransform = GetComponent<RectTransform>();
        Destroy(gameObject, 1);
    }

    void Start()
    {
        currentValue = float.Parse(numberText.text);
        targetValue = currentValue;
    }

    IEnumerator CountTo(float targetValue)
    {
        var rate = Mathf.Abs(targetValue - currentValue) / countDuration;
        while (currentValue != targetValue)
        {
            currentValue = Mathf.MoveTowards(currentValue, targetValue, rate * Time.deltaTime);
            numberText.text = ((int)currentValue).ToString();
            yield return null;
        }
    }

    public void AddValue(float value)
    {
        targetValue += value;
        if (_C2T != null)
            StopCoroutine(_C2T);
        _C2T = StartCoroutine(CountTo(targetValue));
    }

    public void SetTarget(float target)
    {
        targetValue = target;
        if (_C2T != null)
            StopCoroutine(_C2T);
        _C2T = StartCoroutine(CountTo(targetValue));
    }

    private void Update()
    {
        _rectTransform.localPosition += new Vector3(0, 100, 0) * Time.deltaTime;
    }
}