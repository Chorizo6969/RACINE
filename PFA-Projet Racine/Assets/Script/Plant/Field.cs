using UnityEngine;

/// <summary>
/// plant a seed in a field
/// </summary>
public class Field : MonoBehaviour
{
    /// <summary>
    /// Plant that will grow in the field
    /// </summary>
    [field : SerializeField] public GameObject ThePlant { get; set; }

    /// <summary>
    /// used to know if the field is planted
    /// </summary>
    [field : SerializeField] public bool IsPlanted { get; private set; }

    [field : SerializeField] public bool IsWatered { get; private set; }

    private GameObject _currentPlant;

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
        _currentPlant = null;
    }

    public void WateringField()
    {
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