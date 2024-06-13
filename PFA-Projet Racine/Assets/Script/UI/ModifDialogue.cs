using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModifDialogue : MonoBehaviour
{
    [SerializeField]
    private GameObject _GOdialogue;

    public void modifDialogue1()
    {
        DialogueTutoriel.instance.lines.Clear();
        DialogueTutoriel.instance.lines.Add("WAAAAAA, UNE GRAINE DE BUCHERON, IL FAUT LA PLANTER DANS UN CHAMP !");
        DialogueTutoriel.instance.lines.Add("J-J-JE CONNAIS 3 TYPES DE GRAINES, LES BUCHERONS, LES MINEURS ET LES PLONGEURS. MAIS ATTENTION, ON N'AIME PAS TOUS LES MEMES RESSOURCES !");
        DialogueTutoriel.instance.lines.Add("POUR FABRIQUER UN NOUVEAU COPAIN, TU DOIS PASSER PAR ICI CHEF !");
        _GOdialogue.SetActive(true);
    }

    public void modifDialogue2()
    {
        DialogueTutoriel.instance.lines.Clear();
        DialogueTutoriel.instance.lines.Add("QUEL BEAUUUUU CHAMMMMP ! VOUS ETES TROP FORTTTT ! ON VA ENFIN POUVOIR DEVENIR BEAUCOUP !");
        DialogueTutoriel.instance.lines.Add("LES CHAMPS SONT ESSENTIELS POUR NOTRE CROISSANCE ! CHAQUE HUMAIN A BESOIN D'UN CHAMP ET CHAQUE CHAMP A BESOIN D'UN HUMAIN.");
        DialogueTutoriel.instance.lines.Add("M-M-MAINTNENANT PLANTEZ LA GRAINE QUE VOUS AVEZ DANS VOTRE SUPER CHAMP.");
        DialogueTutoriel.instance.lines.Add("N'OUBLIEZ PAS DE L'ARROSER APRES AVOIR PLANTE VOTRE HUMAIN PLANTE.");
        _GOdialogue.SetActive(true);
    }

    public void modifDialogue3()
    {
        DialogueTutoriel.instance.lines.Clear();
        DialogueTutoriel.instance.lines.Add("WAAAAAAAAA, IL A REUSSSIIIIIII, IL EST TROP FOOOOORT, VOICI DONC MON PREMIER COPAIN, QU'IL EST BEAU CE NOUVEAU COPAIN.");
        DialogueTutoriel.instance.lines.Add("M-M-MAINTENANT, IL FAUT CONSTRUIRE UNE CABANE POUR VOTRE HUMAIN BUCHERON.");
        DialogueTutoriel.instance.lines.Add("LES MAISONS NOUS SERVENT D'ENDROIT POUR FAIRE DODO, VOUS POURREZ DONC PLANTER PLUSSSS DE COPAINS. ATTENTION CAR LES BATIMENTS A METIER N'ONT QUE 2 OUTILS MAX POUR LES HUMAINS PLANTES !");
        DialogueTutoriel.instance.lines.Add("DONC OBSERVE BIEN LE NOMBRE D'HUMAINS PLANTES ET LES BATIMENTS POUR TOUJOURS POUVOIR PLANTER PLUS DE COPAINS.");
        _GOdialogue.SetActive(true);
    }
    public void modifDialogue4()
    {
        DialogueTutoriel.instance.lines.Clear();
        DialogueTutoriel.instance.lines.Add("WAAAAAAAAA VOUS AVEZ REUSSI, VIVE NOTRE GRAND CHEFFFFF ! IL EST TROP FOOOOOORT ! VOUS ETES PRET POUR LANCER VOTRE PREMIERE EXPEDITION DE BUCHERON, CLIQUEZ SUR L'ENTREE DE LA FORET POUR ENVOYER VOTRE HUMAIN PLANTE AU TRAVAIL.");
        DialogueTutoriel.instance.lines.Add("VOUS POUVEZ AUSSI ME FAIRE PLEIN D'AUTRES COPAINS ! ALLEZ VOIR PAPI POUR VOIR LES GRAINES DE MES FUTURS COPAINS !");
        _GOdialogue.SetActive(true);
    }
}
