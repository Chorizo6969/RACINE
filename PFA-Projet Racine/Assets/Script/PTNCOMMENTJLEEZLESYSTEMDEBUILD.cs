using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class PTNCOMMENTJLEEZLESYSTEMDEBUILD : MonoBehaviour
{
    public float cooldown;
    public GameObject BuildSYstemLifeMakerAkaGod;
    public GameObject BuildingAreaKILLER;
    public GameObject Canvas;
    public GameObject AAAAAH;
    public GameObject VFX;

    // Start is called before the first frame update
    void Start()
    { 
        AAAAAH.GetComponent<Fill>().FillSpeed = 1f / cooldown;
    }

    public void JugementDernier()
    {
        BuildSYstemLifeMakerAkaGod.SetActive(true);
        Destroy(BuildingAreaKILLER);
        Destroy(Canvas);
        VFX.SetActive(true);
    }
}