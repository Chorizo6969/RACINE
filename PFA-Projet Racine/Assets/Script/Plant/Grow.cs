using UnityEngine;

/// <summary>
/// Make the plant grow
/// </summary>
public class Grow : MonoBehaviour
{
    /// <summary>
    /// speed at which the plant will grow
    /// </summary>
    [field : SerializeField] public float _growSpeed {  get; private set; }
            
    /// <summary>
    /// height of the plant at which it will stop growing
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