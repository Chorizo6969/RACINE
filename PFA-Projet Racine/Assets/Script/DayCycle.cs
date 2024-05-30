using TMPro;
using UnityEngine;

/// <summary>
/// Script qui gère le cycle Jour / Nuit du jeu
/// </summary>
public class DayCycle : MonoBehaviour
{
    /// <summary>
    /// variable int qui gère la vitesse du soleil
    /// </summary>
    [SerializeField]
    private float _sunSpeed = 0.5f;
    [SerializeField]
    private float _time = 0f;
    [SerializeField]
    private int _cycleCount = 1;
    [SerializeField]
    private TextMeshProUGUI _actualDay;
    [SerializeField]
    private GameObject _horloge;

    private void Start()
    {
        //Time.timeScale = 8;
    }

    private void Update()
    {
        _horloge.transform.Rotate(Time.deltaTime * new Vector3(0, 0, _sunSpeed));
        gameObject.transform.Rotate(Time.deltaTime *  new Vector3(_sunSpeed, 0, 0));
        _time += Time.deltaTime * _sunSpeed;
        if (_time >= 360)
        {
            _time = 0f;
            _cycleCount += 1;
            _actualDay.text = _cycleCount.ToString();
        }
    }
}
