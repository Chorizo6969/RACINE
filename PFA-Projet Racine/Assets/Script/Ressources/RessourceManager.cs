using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
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
    public int _wood;

    /// <summary>
    /// Quantité maximum de bois
    /// </summary>
    public int _maxWood;

    /// <summary>
    /// Texte qui affiche la quantité de bois
    /// </summary>
    [SerializeField] private TextMeshProUGUI _woodText;

    /// <summary>
    /// Quantité actuelle d'eau
    /// </summary>
    public int _water;

    /// <summary>
    /// Quantité maximum d'eau
    /// </summary>
    public int _maxWater;

    /// <summary>
    /// Texte qui affiche la quantité d'eau
    /// </summary>
    [SerializeField] private TextMeshProUGUI _waterText;

    /// <summary>
    /// Quantité actuelle de pierre
    /// </summary>
    public int _stone;

    /// <summary>
    /// Quantité maximum de pierre
    /// </summary>
    public int _maxStone;

    /// <summary>
    /// texte qui affiche la quantité de pierre
    /// </summary>
    [SerializeField] private TextMeshProUGUI _stoneText;

    [SerializeField] private GameObject AddingScoreText;

    public GameObject SpawnWood;
    public GameObject SpawnWater;
    public GameObject SpawnStone;

    [SerializeField] private GameObject _panelParent;

    /// <summary>
    /// Texte d'erreur affiché quand on a pas assez de ressources pour poser un batiment
    /// </summary>
    [SerializeField] private GameObject _errorText;

    public Animator _animatorRessource;
    public Animator _animatorRessource2;
    public Animator _animatorRessource3;

    public static RessourceManager Instance;

    

    private void Awake()
    {
        Instance = this;
    }

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
        if (_wood < _maxWood)
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

            _animatorRessource.SetTrigger("Wood");
            _animatorRessource.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "+ " + amount.ToString() + " bois";
            GameObject newWoodText = Instantiate(AddingScoreText);
            newWoodText.name = "wood";
            newWoodText.transform.SetParent(_panelParent.transform, true);
            newWoodText.transform.position = SpawnWood.transform.position;
            newWoodText.GetComponent<TextMeshProUGUI>().color = new Color(0.7803922f, 0.5882353f, 0.3843138f);
            newWoodText.GetComponent<Count>().AddValue(amount);

            StartCoroutine(WoodAttend(1, amount));
        }
        else if (amount < 0)
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

            GameObject newWoodText = Instantiate(AddingScoreText);
            newWoodText.name = "wood";
            newWoodText.transform.SetParent(_panelParent.transform, true);
            newWoodText.transform.position = SpawnWood.transform.position;
            newWoodText.GetComponent<TextMeshProUGUI>().color = new Color(0.7803922f, 0.5882353f, 0.3843138f);
            newWoodText.GetComponent<Count>().AddValue(amount);

            StartCoroutine(WoodAttend(1, amount));
        }
        else if (_wood == _maxWood)
        {
            //Debug.Log("Stockage WOOD full");
        }

        if (StockBatListManager.instance.listWoodStock.Count != 0)
        {
            foreach (GameObject bat in StockBatListManager.instance.listWoodStock)
            {
                bat.GetComponent<FillRessourceStock>().SetGoodStock(_wood, _maxWood);
            }
        }
    }

    public void AddWoodStock(int amount)
    {
        _maxWood += amount;
        StartCoroutine(WoodAttend(0, amount));
    }

    /// <summary>
    /// Fonction qui permet de modifier la quantité d'eau
    /// </summary>
    /// <param name="amount">Quantité de d'eau à ajouter (un nombre négatif diminu la quantité)</param>
    public void EditWaterAmount(int amount)
    {
        if (_water < _maxWater)
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
            _animatorRessource3.SetTrigger("Water");
            _animatorRessource3.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "+ " + amount.ToString() + " eau";
            GameObject newWaterText = Instantiate(AddingScoreText);
            newWaterText.name = "water";
            newWaterText.transform.SetParent(_panelParent.transform, true);
            newWaterText.transform.position = SpawnWater.transform.position;
            newWaterText.GetComponent<TextMeshProUGUI>().color = new Color(0.6941177f, 0.8274511f, 0.8980393f);
            newWaterText.GetComponent<Count>().AddValue(amount);

            StartCoroutine(WaterAttend(1, amount));
        }
        else if (amount < 0)
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

            GameObject newWaterText = Instantiate(AddingScoreText);
            newWaterText.name = "water";
            newWaterText.transform.SetParent(_panelParent.transform, true);
            newWaterText.transform.position = SpawnWater.transform.position;
            newWaterText.GetComponent<TextMeshProUGUI>().color = new Color(0.6941177f, 0.8274511f, 0.8980393f);
            newWaterText.GetComponent<Count>().AddValue(amount);

            StartCoroutine(WaterAttend(1, amount));
        }
        else if ( _water == _maxWater)
        {
            //Debug.Log("Stockage WATER full");
        }

        if (StockBatListManager.instance.listWaterStock.Count != 0)
        {
            foreach (GameObject bat in StockBatListManager.instance.listWaterStock)
            {
                bat.GetComponent<FillRessourceStock>().SetGoodStock(_water, _maxWater);
            }
        }
    }

    public void AddWaterStock(int amount)
    {
        _maxWater += amount;
        StartCoroutine(WaterAttend(0, amount));
    }

    /// <summary>
    /// Fonction qui permet de modifier la quantité de pierre
    /// </summary>
    /// <param name="amount">Quantité de de pierre à ajouter (un nombre négatif diminu la quantité)</param>
    public void EditStoneAmount(int amount)
    {
        if (_stone < _maxStone)
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

            _animatorRessource2.SetTrigger("Stone");
            _animatorRessource2.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "+ " + amount.ToString() + " stone";
            GameObject newStoneText = Instantiate(AddingScoreText);
            newStoneText.name = "water";
            newStoneText.transform.SetParent(_panelParent.transform, true);
            newStoneText.transform.position = SpawnStone.transform.position;
            newStoneText.GetComponent<TextMeshProUGUI>().color = new Color(0.7882354f, 0.7490196f, 0.7803922f);
            newStoneText.GetComponent<Count>().AddValue(amount);

            StartCoroutine(StoneAttend(1, amount));
        }
        else if (amount < 0)
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

            GameObject newStoneText = Instantiate(AddingScoreText);
            newStoneText.name = "water";
            newStoneText.transform.SetParent(_panelParent.transform, true);
            newStoneText.transform.position = SpawnStone.transform.position;
            newStoneText.GetComponent<TextMeshProUGUI>().color = new Color(0.7882354f, 0.7490196f, 0.7803922f);
            newStoneText.GetComponent<Count>().AddValue(amount);

            StartCoroutine(StoneAttend(1, amount));
        }
        else if (_stone == _maxStone)
        {
            //Debug.Log("Stockage STONE full");
        }

        if (StockBatListManager.instance.listStoneStock.Count != 0)
        {
            foreach (GameObject bat in StockBatListManager.instance.listStoneStock)
            {
                bat.GetComponent<FillRessourceStock>().SetGoodStock(_stone, _maxStone);
            }
        }
    }

    public void AddStoneStock(int amount)
    {
        _maxStone += amount;
        StartCoroutine(StoneAttend(0, amount));
    }

    /// <summary>
    /// Fonction qui vérifie si on a assez de ressource pour poser un batiment
    /// </summary>
    /// <param name="_woodCost">le cout en boit du batiment pour lequel on vérifie</param>
    /// <param name="_stoneCost">le cout en pierre du batiment pour lequel on vérifie</param>
    /// <returns>retourne vrai ou faux</returns>
    public bool CheckIfCanBuild(int _woodCost, int _stoneCost, int _waterCost)
    {
        if (_wood - _woodCost >= 0 && _stone - _stoneCost >= 0 && _water - _waterCost >= 0)
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

    IEnumerator WoodAttend(float _time, int quantity)
    {
        yield return new WaitForSeconds(_time);
        _animatorRessource.SetTrigger("Wood2");
        _animatorRessource.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "+ " + quantity.ToString() + " bois";
        _woodText.text = _wood.ToString() + "/" + _maxWood.ToString();
        if (StockBatListManager.instance != null )
        {
            foreach (GameObject bat in StockBatListManager.instance.listWoodStock)
            {
                bat.GetComponent<FillRessourceStock>().SetGoodStock(_wood, _maxWood);
            }
        }
    }

    IEnumerator WaterAttend(float _time, int quantity)
    {
        yield return new WaitForSeconds(_time);
        _animatorRessource3.SetTrigger("Water2");
        _animatorRessource3.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "+ " + quantity.ToString() + " eau";
        _waterText.text = _water.ToString() + "/" + _maxWater.ToString();
        if (StockBatListManager.instance != null)
        {
            foreach (GameObject bat in StockBatListManager.instance.listWaterStock)
            {
                bat.GetComponent<FillRessourceStock>().SetGoodStock(_water, _maxWater);
            }
        }
    }

    IEnumerator StoneAttend(float _time, int quantity)
    {
        yield return new WaitForSeconds(_time);
        _animatorRessource2.SetTrigger("Stone2");
        _animatorRessource2.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "+ " + quantity.ToString() + " stone";
        _stoneText.text = _stone.ToString() + "/" + _maxStone.ToString();
        if (StockBatListManager.instance != null)
        {
            foreach (GameObject bat in StockBatListManager.instance.listStoneStock)
            {
                bat.GetComponent<FillRessourceStock>().SetGoodStock(_stone, _maxStone);
            }
        }
    }
}