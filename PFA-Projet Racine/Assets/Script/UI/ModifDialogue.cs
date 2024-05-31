using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifDialogue : MonoBehaviour
{
    [SerializeField]
    private GameObject _GOdialogue;

    public void modifDialogue1()
    {
        DialogueTutoriel.instance.lines.Clear();
        DialogueTutoriel.instance.lines.Add("WAAAAAA, UNE GRAINE, IL FAUT LA PLANTER");
        DialogueTutoriel.instance.lines.Add("CONSTRUISEZ UN CHAMP");
        _GOdialogue.SetActive(true);
    }

    public void modifDialogue2()
    {
        DialogueTutoriel.instance.lines.Clear();
        DialogueTutoriel.instance.lines.Add("QUEL BEAUUUUU CHAMMMMP ! VOUS ÊTES TROP FORTTTT !");
        DialogueTutoriel.instance.lines.Add("M-M-MAINTNENANT PLANTEZ LA GRAINE QUE VOUS AVEZ DANS VOTRE INVENTAIRE");
        _GOdialogue.SetActive(true);
    }

    public void modifDialogue3()
    {
        DialogueTutoriel.instance.lines.Clear();
        DialogueTutoriel.instance.lines.Add("WAAAAAAAAA, IL A RÉUSSSIIIIIII, IL EST TROP FOOOOORT");
        DialogueTutoriel.instance.lines.Add("M-M-MAINTENANT, IL FAUT CONSTRUIRE DES MAISONS POUR VOS HUMAINS PLAAAAANTES");
        DialogueTutoriel.instance.lines.Add("UTILISEZ LES MATÉRIAUX POUR EN CONSTRUIRE UNE.");
        _GOdialogue.SetActive(true);
    }
    public void modifDialogue4()
    {
        DialogueTutoriel.instance.lines.Clear();
        DialogueTutoriel.instance.lines.Add("WAAAAAAAAA VOUS AVEZ RÉUSSI, VIVE NOTRE GRAND CHEFFFFF ! IL EST TROP FOOOOOORT !!!");
        DialogueTutoriel.instance.lines.Add("OHHHHH REGRADEZ, L'HUMAIN PLANTE EST NÉ");
        _GOdialogue.SetActive(true);
    }
}
