using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class IntroManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _activation;

    [SerializeField]
    private GameObject _panelRacine;

    [SerializeField]
    private ModifDialogue _modif;

    [SerializeField]
    private DialogueTutoriel _dialogue;

    [SerializeField]
    private List<GameObject> fleche;

    [SerializeField]
    private GameObject _panelIntroduction;

    public bool clic;
    public bool bouliste;

    public int id = 0;

    public static IntroManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void Start()
    {
        Distribution();
    }

    public async void Distribution()
    {
        while (!_dialogue._isfinish) await Task.Yield();
        RessourceManager.Instance.EditWoodAmount(20);
        RessourceManager.Instance.EditWaterAmount(45);
        LockIntro.instance.Racine.GetComponent<MeshCollider>().enabled = true;
        fleche[0].SetActive(true);
        while (id != 1) await Task.Yield();
        fleche[0].SetActive(false);
        _panelRacine.SetActive(false);
        LockIntro.instance.Racine.GetComponent<MeshCollider>().enabled = false;
        Dialogue2();
    }
    public async void Dialogue2()
    {
        _modif.modifDialogue1();
        LockIntro.instance.House.interactable = false;
        await Task.Delay(2000);
        while (!_dialogue._isfinish) await Task.Yield();
        LockIntro.instance.House.interactable = true;
        LockIntro.instance.Champ.interactable = true;
        fleche[1].SetActive(true);
        while (id != 2) await Task.Yield();
        fleche[1].SetActive(false);
        fleche[2].SetActive(true);
        while (id != 3) await Task.Yield();
        fleche[2].SetActive(false);
        LockIntro.instance.House.interactable = false;
        Dialogue3();
    }
    public async void Dialogue3()
    {
        _modif.modifDialogue2();
        LockIntro.instance.House.interactable = false;
        await Task.Delay(2000);
        LockIntro.instance.House.interactable = false;
        while (!_dialogue._isfinish) await Task.Yield();
        LockIntro.instance.House.interactable = true;
        LockIntro.instance.Champ.interactable = false;
        LockIntro.instance.Bucheron.interactable = true;
        fleche[1].SetActive(true);
        bouliste = true;
        while (id != 4) await Task.Yield();
        fleche[1].SetActive(false);
        fleche[3].SetActive(true);
        while (!clic) await Task.Yield();
        bouliste = false;
        fleche[3].SetActive(false);
        while (ExpeditionLoot.instance.listBucheron.Count == 0) await Task.Yield();
        LockIntro.instance.House.interactable = false;
        Debug.Log(id);
        if (Jkh.Instance.BOOLISTEBUILDINGPANEL)
        {
            UIManager.Instance.ActivationUi();
        }
        Dialogue4();
    }
    public async void Dialogue4()
    {
        _modif.modifDialogue3();
        await Task.Delay(2000);
        LockIntro.instance.House.interactable = false;
        while (!_dialogue._isfinish) await Task.Yield();
        LockIntro.instance.House.interactable = true;
        LockIntro.instance.Batiment.interactable = true;
        LockIntro.instance.Bucheron.interactable = false;
        LockIntro.instance.MaisonBucheron.interactable = true;
        bouliste = true;
        fleche[1].SetActive(true);
        while (id != 6) await Task.Yield();
        fleche[1].SetActive(false);
        fleche[4].SetActive(true);
        while (id != 7) await Task.Yield();
        fleche[4].SetActive(false);
        fleche[3].SetActive(true);
        while (id != 8) await Task.Yield();
        fleche[3].SetActive(false);
        _modif.modifDialogue4();
        await Task.Delay(2000);
        while (!_dialogue._isfinish) await Task.Yield();
        LockIntro.instance.House.interactable = true;
        LockIntro.instance.Champ.interactable = true;
        LockIntro.instance.Bucheron.interactable = true;
        LockIntro.instance.MaisonBucheron.interactable = true;
        LockIntro.instance.Lock();
        LockIntro.instance.Racine.GetComponent<MeshCollider>().enabled = true;
        _panelIntroduction.SetActive(false);
    }

    public void cliked()
    {
        clic = true;
    }

}
