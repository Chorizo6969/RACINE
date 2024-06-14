using System.Threading.Tasks;
using UnityEngine;

public class TutoMineur : MonoBehaviour
{
    [SerializeField]
    private ModifDialogue modifDialogue;

    [SerializeField]
    private DialogueTutoriel _dialogue;

    [SerializeField]
    private GameObject _panelDialogue;

    public static TutoMineur Instance;

    private void Awake()
    {
        TutoMineur.Instance = this;
    }

    public async void LevelUpRacine()
    {
        _panelDialogue.SetActive(true);
        modifDialogue.modifDialogue6();
        while (!_dialogue._isfinish) await Task.Yield();
        _panelDialogue.SetActive(false);
    }
}