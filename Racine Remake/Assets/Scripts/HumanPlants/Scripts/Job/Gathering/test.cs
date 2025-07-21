using UnityEngine;

public class test : MonoBehaviour
{
    private HumanPlants h;
    private void Start()
    {
        h = this.GetComponent<HumanPlants>();
        RécolteurEau.Instance.ActorInJob.Add(h);
    }
}
