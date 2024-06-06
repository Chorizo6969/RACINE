using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockIntro : MonoBehaviour
{
    [SerializeField]
    private List<Button> Lockedlife;

    public Button House;
    public Button Champ;
    public Button Bucheron;
    public Button MaisonBucheron;
    public GameObject Racine;

    public static LockIntro instance;

    public void Awake()
    {
        instance = this;
    }

    public void Start()
    {
        Racine.GetComponent<MeshCollider>().enabled = false;
        foreach (Button obj in Lockedlife)
        {
            obj.interactable = false;
        }
        House.interactable = false;
        Champ.interactable = false;
        Bucheron.interactable = false;
        MaisonBucheron.interactable = false;
    }

    public void Lock()
    {
        foreach (Button obj in Lockedlife)
        {
            obj.interactable = true;
        }
    }
}
