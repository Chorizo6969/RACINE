using UnityEngine;

/// <summary>
/// Script qui fait pousser la plante
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
        //fait monter la plante et l'arrete lorsqu'elle est à sa hauteur max
        transform.position += new Vector3(0, _growSpeed, 0) * Time.deltaTime;
        if (transform.position.y >= _maxHighGrow)
        {
            transform.position = new Vector3(transform.position.x, _maxHighGrow, transform.position.z);
            Destroy(GetComponent<Grow>());
        }
    }
}