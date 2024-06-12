using UnityEngine;

public class ActiveDialogue : MonoBehaviour
{
    private void OnDisable()
    {
        Dialoguemarchand.instance.Desactive();
    }
}
