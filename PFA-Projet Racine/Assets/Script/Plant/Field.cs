using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Script qui gère les champs
/// </summary>
public class Field : MonoBehaviour
{
    /// <summary>
    /// Référence de la graine qui va pousser
    /// </summary>
    [field : SerializeField] public GameObject ThePlant { get; set; }

    /// <summary>
    /// Booléen qui renvoit si la graine a finit de pousser ou pas
    /// </summary>
    [field : SerializeField] public bool IsPlanted { get; private set; }

    /// <summary>
    /// Booléen qui renvoit si le champ a été arrosé
    /// </summary>
    [field : SerializeField] public bool IsWatered { get; private set; }

    /// <summary>
    /// référence à la plante qui pousse actuellement dans le champ
    /// </summary>
    [Field : SerializeField] public GameObject _currentPlant {  get; private set; }

    /// <summary>
    /// référence le cercle d'avancement du champ
    /// </summary>
    [field : SerializeField] public GameObject _progressCircle { get; private set; }

    private void Start()
    {
        _progressCircle.SetActive(false);
    }

    public void PlantField()
    {
        //check if the gameObject in the field is a seed and if the field is not planted
        if (!IsPlanted)
        {
            //plant the field
            _currentPlant = Instantiate(ThePlant);
            _currentPlant.transform.position = new Vector3(transform.position.x, _currentPlant.transform.position.y, transform.position.z);
            IsPlanted = true;
            _currentPlant.SetActive(false);
        }
    }
    
    public void HarvestField()
    {
        IsPlanted = false;
        IsWatered = false;
        _progressCircle.GetComponentInChildren<Image>().fillAmount = 0;
        _progressCircle.SetActive(false);
        GetComponent<Spawn>().Spawner();
        
        Destroy(_currentPlant);
    }

    public void WateringField()
    {
        _progressCircle.GetComponentInChildren<Fill>().FillSpeed = _currentPlant.GetComponent<Grow>()._growSpeed;
        _progressCircle?.SetActive(true);
        IsWatered = true;
        _currentPlant?.SetActive(true);
    }

    private void Update()
    {
        if (IsPlanted && IsWatered)
        {
            gameObject.GetComponent<MeshRenderer>().material.color = Color.blue;
        }
        else if (IsPlanted) 
        {
            gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
        }
        else
        {
            gameObject.GetComponent<MeshRenderer>().material.color = Color.yellow;
        }
    }
}