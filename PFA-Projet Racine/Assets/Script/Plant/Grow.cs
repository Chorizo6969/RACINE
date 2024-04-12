using UnityEngine;

/// <summary>
/// fait pousser la plante
/// </summary>
public class Grow : MonoBehaviour
{
    /// <summary>
    /// vitesse de croissance de la plante
    /// </summary>
    [field : SerializeField] public float _growSpeed {  get; private set; }
            
    /// <summary>
    /// hauteur max à laquelle
    /// </summary>
    [SerializeField] private float _maxHighGrow;

    void Update()
    {
        //make the plant grow and stop if it rech the max high
        transform.position += new Vector3(0, _growSpeed, 0) * Time.deltaTime;
        if (transform.position.y >= _maxHighGrow)
        {
            transform.position = new Vector3(transform.position.x, _maxHighGrow, transform.position.z);
            Destroy(GetComponent<Grow>());
        }
    }
}