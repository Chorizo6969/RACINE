using System.Threading.Tasks;
using UnityEngine;

public class TutoHuman : MonoBehaviour
{
    [SerializeField]
    private ModifDialogue modifDialogue;

    [SerializeField]
    private DialogueTutoriel _dialogue;

    [SerializeField]
    private GameObject _panelDialogue;

    public static TutoHuman Instance;

    private void Awake()
    {
        TutoHuman.Instance = this;
    }

    public async void WarningTuto()
    {
        if(IncrementHuman.instance._maxBucheron == IncrementHuman.instance._countBucheron
          || IncrementHuman.instance._maxAquaman == IncrementHuman.instance._countAquaman 
          || IncrementHuman.instance._maxStoneMan == IncrementHuman.instance._countStoneMan)
        {
            _panelDialogue.SetActive(true);
            modifDialogue.modifDialogue5();
            while (!_dialogue._isfinish) await Task.Yield();
            _panelDialogue.SetActive(false);
        }
    }
}
