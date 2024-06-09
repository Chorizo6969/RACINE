using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PTNCOMMENTJLEEZLESYSTEMDEBUILD : MonoBehaviour
{
    public int cooldown;
    public GameObject BuildSYstemLifeMakerAkaGod;
    public GameObject BuildingAreaKILLER;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(JugementDernier());
        Destroy(BuildingAreaKILLER, cooldown);
    }

    IEnumerator JugementDernier()
    {
        yield return new WaitForSeconds(cooldown);
        BuildSYstemLifeMakerAkaGod.SetActive(true);
    }
}