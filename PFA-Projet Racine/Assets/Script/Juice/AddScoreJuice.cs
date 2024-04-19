using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AddScoreJuice : MonoBehaviour
{
    [SerializeField] private float _value;
    [SerializeField] private float _baseValue;
    [SerializeField] private float _speed;
    [SerializeField] private float count;
    private RectTransform _objectTransform;

    private bool _letsGo;

    void Awake()
    {
        _objectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_letsGo)
        {
            gameObject.GetComponent<TextMeshProUGUI>().maxVisibleCharacters = 4;
            count += Time.deltaTime;
            _objectTransform.position +=  Time.deltaTime * new Vector3(0, 1, 0);

            _value -= Time.deltaTime * _baseValue;
            if (_value <= 0)
            {
                _value = 0;
            }

            gameObject.GetComponent<TextMeshProUGUI>().text = _value.ToString();
            if (count >= 1)
            {
                _letsGo = false;
                gameObject.SetActive(false);
            }
        }
    }

    public void ChangeValues(int _valueValue)
    {
        _value = _valueValue;
        _baseValue = _value;
        gameObject.SetActive(true);
        _letsGo = true;
        gameObject.GetComponent<TextMeshProUGUI>().text = _value.ToString();
    }
}