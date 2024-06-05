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
    private Image _image;

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
        fleche[0].SetActive(true);
        while (id != 1) await Task.Yield();
        fleche[0].SetActive(false);
        _panelRacine.SetActive(false);
        Dialogue2();
    
    }
    public async void Dialogue2()
    {
        _modif.modifDialogue1();
        await Task.Delay(2000);
        while (!_dialogue._isfinish) await Task.Yield();
        fleche[1].SetActive(true);
        while (id != 2) await Task.Yield();
        fleche[1].SetActive(false);
        fleche[2].SetActive(true);
        while (id != 3) await Task.Yield();
        fleche[2].SetActive(false);
        Dialogue3();
    }
    public async void Dialogue3()
    {
        _modif.modifDialogue2();
        await Task.Delay(2000);
        while (!_dialogue._isfinish) await Task.Yield();
        fleche[1].SetActive(true);
        bouliste = true;
        while (id != 4) await Task.Yield();
        fleche[1].SetActive(false);
        fleche[3].SetActive(true);
        while (ExpeditionLoot.instance.listBucheron.Count == 0) await Task.Yield();
        bouliste = false;
        fleche[3].SetActive(false);
        Dialogue4();
    }
    public async void Dialogue4()
    {
        _modif.modifDialogue3();
        await Task.Delay(2000);
        while (!_dialogue._isfinish) await Task.Yield();
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
    }

}
