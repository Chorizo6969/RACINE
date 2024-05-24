using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Play : MonoBehaviour
{
    [SerializeField]
    private Animation _anim;

    [SerializeField]
    private Animation _anim2;

    [SerializeField]
    private Button _button1;

    [SerializeField] 
    private Button _button2;

    [SerializeField] 
    private Button _button3;

    [SerializeField] 
    private Button _button4;

    private int _id = 0;


    public void StartAnim()
    {
        _id = 0;
        _anim.Play("Slide");
        _button1.interactable = false;
        _button2.interactable = false;
        _button3.interactable = false;
        _button4.interactable = false;
        StartCoroutine(Delay());
    }

    public void Transition()
    {

    }

    public void Back()
    {
        _id = 1;
        _anim2.Play("ReverseSlide2");
        StartCoroutine(Delay());
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(0.7f);
        _button1.interactable = true;
        _button2.interactable = true;
        _button3.interactable = true;
        _button4.interactable = true;
        if (_id == 0)
        {
            _anim2.gameObject.SetActive(true);
            _anim2.Play("Slide2");
        }
        else
        {
            _anim.Play("ReverseSlide");
        }
    }
}
