using UnityEngine;

public class WalkHuman : MonoBehaviour
{
    public void FixedUpdate()
    {
        transform.Rotate(0,0.5f,0);
    }
}
