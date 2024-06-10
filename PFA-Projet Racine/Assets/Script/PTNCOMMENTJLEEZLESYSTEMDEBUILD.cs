using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PTNCOMMENTJLEEZLESYSTEMDEBUILD : MonoBehaviour
{
    public float cooldown;
    public GameObject BuildSYstemLifeMakerAkaGod;
    public GameObject BuildingAreaKILLER;
    public GameObject Canvas;
    public GameObject AAAAAH;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(JugementDernier());
        Destroy(BuildingAreaKILLER, cooldown);
        Destroy(Canvas, cooldown);
        AAAAAH.GetComponent<Fill>().FillSpeed = 1f / cooldown;
        AAAAAH.GetComponent<Fill>().FillSpeed += AAAAAH.GetComponent<Fill>().FillSpeed * 10 / 100;
        /*Debug.Log(cooldown);
        Debug.Log(1 / cooldown);
        Debug.Log(AAAAAH.GetComponent<Fill>().FillSpeed);*/
    }

    IEnumerator JugementDernier()
    {
        yield return new WaitForSeconds(cooldown);
        BuildSYstemLifeMakerAkaGod.SetActive(true);
    }
}