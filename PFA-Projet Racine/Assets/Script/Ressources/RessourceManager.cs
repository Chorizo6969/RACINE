using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

/// <summary>
/// Script qui gère les ressources du joueur
/// </summary>
public class RessourceManager : MonoBehaviour
{
    [SerializeField] private int _wood;
    [SerializeField] private int _maxWood;
    [SerializeField] private TextMeshProUGUI _woodText;
    [SerializeField] private int _water;
    [SerializeField] private int _maxWater;
    [SerializeField] private TextMeshProUGUI _waterText;
    [SerializeField] private int _stone;
    [SerializeField] private int _maxStone;
    [SerializeField] private TextMeshProUGUI _stoneText;
    [SerializeField] private GameObject _errorText;

    private void Start()
    {
        _woodText.text = _wood.ToString() + "/" + _maxWood.ToString();
        _waterText.text = _water.ToString() + "/" + _maxWater.ToString();
        _stoneText.text = _stone.ToString() + "/" + _maxStone.ToString();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            EditWoodAmount(10);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            EditWoodAmount(50);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            EditWoodAmount(-100);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            EditWaterAmount(10);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            EditWaterAmount(50);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            EditWaterAmount(-100);
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            EditStoneAmount(10);
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            EditStoneAmount(50);
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            EditStoneAmount(-100);
        }

    }

    public void EditWoodAmount(int amount)
    {
        if (_wood <= _maxWood)
        {
            _wood += amount;
            if (_wood >= _maxWood)
            {
                _wood = _maxWood;
            }
            else if (_wood <= 0)
            {
                _wood = 0;
            }
            _woodText.text = _wood.ToString() + "/" + _maxWood.ToString();
        }
        else
        {
            Debug.Log("Stockage full");
        }
    }
    
    public void EditWaterAmount(int amount)
    {
        if (_water <= _maxWater)
        {
            _water += amount;
            if (_water >= _maxWater)
            {
                _water = _maxWater;
            }
            else if (_water <= 0)
            {
                _water = 0;
            }
            _waterText.text = _water.ToString() + "/" + _maxWater.ToString();
        }
        else
        {
            Debug.Log("Stockage full");
        }
    }
    
    public void EditStoneAmount(int amount)
    {
        if (_stone <= _maxStone)
        {
            _stone += amount;
            if (_stone >= _maxStone)
            {
                _stone = _maxStone;
            }
            else if (_stone <= 0)
            {
                _stone = 0;
            }
            _stoneText.text = _stone.ToString() + "/" + _maxStone.ToString();
        }
        else
        {
            Debug.Log("Stockage full");
        }
    }

    public bool CheckIfCanBuild(int _woodCost, int _stoneCost)
    {
        if (_wood - _woodCost >= 0 && _stone - _stoneCost >= 0)
        {
            return true;
        }
        else 
        {
            _errorText.SetActive(true);
            StartCoroutine(SetActiveFalseErrorText());
            return false;
        }
    }

    IEnumerator SetActiveFalseErrorText()
    {
        yield return new WaitForSeconds(2.5f);
        _errorText.SetActive(false);
    }
}