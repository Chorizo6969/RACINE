using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Play : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;

    [SerializeField]
    private Button _button1;

    [SerializeField] 
    private Button _button2;

    [SerializeField] 
    private Button _button3;

    [SerializeField] 
    private Button _button4;

    [SerializeField]
    private GameObject _panel;


    public void StartAnim()
    {
        _animator.SetBool("IsBack", false);
        _animator.SetBool("IsPlay", true);
        _button1.interactable = false;
        _button2.interactable = false;
        _button3.interactable = false;
        _button4.interactable = false;
        StartCoroutine(Delay());
    }

    public void panel2()
    {
        _animator.SetBool("IsBack", true);
        _animator.SetBool("IsPlay", false);
    }
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(1);
        _button1.interactable = true;
        _button2.interactable = true;
        _button3.interactable = true;
        _button4.interactable = true;
    }
}
