using UnityEngine;

/// <summary>
/// plant a seed in a field
/// </summary>
public class Plant : MonoBehaviour
{
    /// <summary>
    /// Plant that will grow in the field
    /// </summary>
    [field : SerializeField] public GameObject ThePlant { get; set; }
    /// <summary>
    /// used to know if the field is planted
    /// </summary>
    [field : SerializeField] public bool IsPlanted { get; private set; }

    private GameObject _currentPlant;

    public void PlantField()
    {
        //check if the gameObject in the field is a seed and if the field is not planted
        if (!IsPlanted)
        {
            //plant the field
            GameObject newPlant = Instantiate(ThePlant);
            newPlant.transform.position = new Vector3(transform.position.x, newPlant.transform.position.y, transform.position.z);
            IsPlanted = true;
        }
    }
    
    public void HarvestField()
    {
        IsPlanted = false;
    }

    private void Update()
    {
        if (IsPlanted)
        {
            gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
        }
        else
        {
            gameObject.GetComponent<MeshRenderer>().material.color = Color.blue;
        }
    }
}