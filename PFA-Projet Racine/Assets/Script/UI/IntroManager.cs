using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class IntroManager : MonoBehaviour
{
    [SerializeField]
    private ModifDialogue _modif;

    [SerializeField]
    private DialogueTutoriel _dialogue;

    [SerializeField]
    private GameObject fleche;

    [SerializeField]
    private Animation _focus;

    [SerializeField]
    private Animation _unfocus;

    [SerializeField]
    private Image _image;

    private async Task Intro()
    {
        //Transition fleche + focus lorsque fin dialogue
        //lorsque clic fin fleche et unfocus
        //Lorsque champ placé Dialogue 3
        //Fin dialogue 3
        //Lorsque graine placé Dialogue 4
        //fleche + focus fin dialogue 4
        //lorsque clic fin fleche et unfocus
        //lorsque humain plante apparait dialogue 5
        await Task.Yield();
    }
    public async void Dialogue2()  //Lorsque clic sur la graine bucheron dialogue 2
    {
        _modif.modifDialogue1();
        await Task.Delay(2000);
        while (!_dialogue.isfinish) await Task.Yield();
        Debug.Log("dfbser");


    }
    public void Dialogue3()
    {
        _modif.modifDialogue2();
    }
    public void Dialogue4()
    {
        _modif.modifDialogue3();
    }
    public void Dialogue5()
    {
        _modif.modifDialogue4();
    }
    public void Dialogue6()
    {
        _modif.modifDialogue5();
    }
    public void Dialogue7()
    {
        _modif.modifDialogue6();
    }
}
