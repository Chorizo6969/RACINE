using UnityEngine;

public class test : MonoBehaviour
{
    private HumanPlants h;
    private void Start()
    {
        h = this.GetComponent<HumanPlants>();
        R�colteurEau.Instance.ActorInJob.Add(h);
    }
}
