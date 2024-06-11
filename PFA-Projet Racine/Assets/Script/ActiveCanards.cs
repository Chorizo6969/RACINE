using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class ActiveCanards : MonoBehaviour
{
    [SerializeField]
    private GameObject _canard1;

    [SerializeField]
    private GameObject _canard2;

    [SerializeField]
    private GameObject _canard3;

    [SerializeField] 
    private GameObject _canard4;

    [SerializeField]
    private GameObject _canard5;

    public async void Start()
    {
        await Task.Delay(2000);
        _canard1.SetActive(true);
        _canard2.SetActive(true);
        await Task.Delay(2000);
        _canard3.SetActive(true);
        _canard4.SetActive(true);
        _canard5.SetActive(true);
    }
}
