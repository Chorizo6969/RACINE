using UnityEngine;

public class ActiveDialogue : MonoBehaviour
{
    private void OnEnable()
    {
        Dialoguemarchand.instance.StartDialogue();
    }
    private void OnDisable()
    {
        Dialoguemarchand.instance.Desactive();
    }
}
