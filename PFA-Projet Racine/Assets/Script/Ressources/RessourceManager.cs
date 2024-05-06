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
    /// <summary>
    /// Quantité actuelle de bois
    /// </summary>
    [SerializeField] private int _wood;

    /// <summary>
    /// Quantité maximum de bois
    /// </summary>
    [SerializeField] private int _maxWood;

    /// <summary>
    /// Texte qui affiche la quantité de bois
    /// </summary>
    [SerializeField] private TextMeshProUGUI _woodText;

    /// <summary>
    /// Quantité actuelle d'eau
    /// </summary>
    [SerializeField] private int _water;

    /// <summary>
    /// Quantité maximum d'eau
    /// </summary>
    [SerializeField] private int _maxWater;

    /// <summary>
    /// Texte qui affiche la quantité d'eau
    /// </summary>
    [SerializeField] private TextMeshProUGUI _waterText;

    /// <summary>
    /// Quantité actuelle de pierre
    /// </summary>
    [SerializeField] private int _stone;

    /// <summary>
    /// Quantité maximum de pierre
    /// </summary>
    [SerializeField] private int _maxStone;

    /// <summary>
    /// texte qui affiche la quantité de pierre
    /// </summary>
    [SerializeField] private TextMeshProUGUI _stoneText;

    [SerializeField] private TextMeshProUGUI AddingWaterText;

    [SerializeField] private TextMeshProUGUI AddingWoodText;

    [SerializeField] private TextMeshProUGUI AddingStoneText;

    /// <summary>
    /// Texte d'erreur affiché quand on a pas assez de ressources pour poser un batiment
    /// </summary>
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

    /// <summary>
    /// Fonction qui permet de modifier la quantité de bois
    /// </summary>
    /// <param name="amount">Quantité de bois à ajouter (un nombre négatif diminu la quantité)</param>
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
            AddingWoodText.gameObject.SetActive(true);
            AddingWoodText.GetComponent<AddScoreJuice>().ChangeValues(amount);
            StartCoroutine(WoodAttend());
        }
        else
        {
            Debug.Log("Stockage full");
        }
    }

    /// <summary>
    /// Fonction qui permet de modifier la quantité d'eau
    /// </summary>
    /// <param name="amount">Quantité de d'eau à ajouter (un nombre négatif diminu la quantité)</param>
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
            AddingWaterText.gameObject.SetActive(true);
            AddingWaterText.GetComponent<AddScoreJuice>().ChangeValues(amount);
            StartCoroutine(WaterAttend());
        }
        else
        {
            Debug.Log("Stockage full");
        }
    }

    /// <summary>
    /// Fonction qui permet de modifier la quantité de pierre
    /// </summary>
    /// <param name="amount">Quantité de de pierre à ajouter (un nombre négatif diminu la quantité)</param>
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
            AddingStoneText.gameObject.SetActive(true);
            AddingStoneText.GetComponent<AddScoreJuice>().ChangeValues(amount);
            StartCoroutine(StoneAttend());
        }
        else
        {
            Debug.Log("Stockage full");
        }
    }

    /// <summary>
    /// Fonction qui vérifie si on a assez de ressource pour poser un batiment
    /// </summary>
    /// <param name="_woodCost">le cout en boit du batiment pour lequel on vérifie</param>
    /// <param name="_stoneCost">le cout en pierre du batiment pour lequel on vérifie</param>
    /// <returns>retourne vrai ou faux</returns>
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

    /// <summary>
    /// SetActive false le texte d'erreur après
    /// </summary>
    /// <returns></returns>
    IEnumerator SetActiveFalseErrorText()
    {
        yield return new WaitForSeconds(2.5f);
        _errorText.SetActive(false);
    }

    IEnumerator WoodAttend()
    {
        yield return new WaitForSeconds(1);
        _woodText.text = _wood.ToString() + "/" + _maxWood.ToString();
    }

    IEnumerator WaterAttend()
    {
        yield return new WaitForSeconds(1);
        _waterText.text = _water.ToString() + "/" + _maxWater.ToString();
    }

    IEnumerator StoneAttend()
    {
        yield return new WaitForSeconds(1);
        _stoneText.text = _stone.ToString() + "/" + _maxStone.ToString();
    }

}