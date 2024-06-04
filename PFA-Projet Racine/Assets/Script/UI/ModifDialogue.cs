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
        DialogueTutoriel.instance.lines.Add("WAAAAAA, UNE GRAINE, IL FAUT LA PLANTER DANS UN CHAMP !");
        DialogueTutoriel.instance.lines.Add("CONSTRUISEZ UN CHAMP DEPUIS ICI CHEF !");
        _GOdialogue.SetActive(true);
    }

    public void modifDialogue2()
    {
        DialogueTutoriel.instance.lines.Clear();
        DialogueTutoriel.instance.lines.Add("QUEL BEAUUUUU CHAMMMMP ! VOUS ÊTES TROP FORTTTT ! ON VA ENFIN POUVOIR DEVENIR BEAUCOUP.");
        DialogueTutoriel.instance.lines.Add("M-M-MAINTNENANT PLANTEZ LA GRAINE QUE VOUS AVEZ DANS VOTRE SUPER CHAMP.");
        DialogueTutoriel.instance.lines.Add("N'OUBLIEZ PAS D'ARROSER VOTRE CHAMP APRES AVOIR PLANTE VOTRE HUMAIN PLANTE");
        _GOdialogue.SetActive(true);
    }

    public void modifDialogue3()
    {
        DialogueTutoriel.instance.lines.Clear();
        DialogueTutoriel.instance.lines.Add("WAAAAAAAAA, IL A RÉUSSSIIIIIII, IL EST TROP FOOOOORT");
        DialogueTutoriel.instance.lines.Add("M-M-MAINTENANT, IL FAUT CONSTRUIRE UNE MAISON DE BUCHERON POUR VOTRE HUMAIN PLAAAAANTE");
        DialogueTutoriel.instance.lines.Add("ILS ONT BESOIN D'UN LIEU DE TRAVAIL POUR COUPER LEURS BOIS");
        DialogueTutoriel.instance.lines.Add("VOICI QUELQUES RESSOURCES POUR COMMENCER.");
        _GOdialogue.SetActive(true);
    }
    public void modifDialogue4()
    {
        DialogueTutoriel.instance.lines.Clear();
        DialogueTutoriel.instance.lines.Add("WAAAAAAAAA VOUS AVEZ RÉUSSI, VIVE NOTRE GRAND CHEFFFFF ! IL EST TROP FOOOOOORT !");
        DialogueTutoriel.instance.lines.Add("OHHHHH REGRADEZ, L'HUMAIN PLANTE EST NÉ, CLIQUEZ DESSUS POUR LE RECUPERER.");
        _GOdialogue.SetActive(true);
    }
}
