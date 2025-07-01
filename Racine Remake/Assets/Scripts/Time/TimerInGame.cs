using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeInGame : MonoBehaviour
{
    #region Variable
    [Header("Light and color")]
    [SerializeField] private List<Gradient> _listGradient = new(); //Nuit, Levée du soleil, aprem, couché de soleil
    [SerializeField] private Light _globalLight;
    [SerializeField][Tooltip("Temps en s que mets la transition de couleur du gardient (par défaut 10s)")] private float _transitionGradientTime = 10;
    [SerializeField] private int _timeSpeed = 2;

    [Header("UI")]
    [SerializeField] TextMeshProUGUI _hourTxt;
    [SerializeField] private RectTransform _clockImage;

    [Header("Timer Settings")]
    [SerializeField] private int days;
    public int Days { get { return days; } set { days = value; } }

    private int _minutes = 59;
    private float _tempsSecond;
    public int Minutes { get { return _minutes; } set { _minutes = value; OnMinutesChange(value); } }

    private int _hours = 5;
    public int Hours { get { return _hours; } set { _hours = value; OnHoursChange(value); } }

    #endregion

    public void FixedUpdate()
    {
        _globalLight.transform.Rotate(Vector3.up, 0.001f / (1440f / 4f) * 360f, Space.World);
        _tempsSecond += Time.deltaTime * _timeSpeed;

        if (_tempsSecond >= 1)
        {
            Minutes += 1;
            _tempsSecond = 0;
        }
    }

    private void OnMinutesChange(int value)
    {
        if (value >= 60)
        {
            Hours++;
            _minutes = 0;
        }
        if (Hours >= 24)
        {
            Hours = 0;
            Days++;
        }
        UpdateClockRotation();
    }

    private void OnHoursChange(int value)
    {
        _hourTxt.text = value.ToString() + "h";
        if (value == 6) //Levée du soleil
        {
            StartCoroutine(LerpLight(_listGradient[0], _transitionGradientTime)); //TO DO : La transition est fixe et pas proportionelle à la vitesse du temps
        }
        else if (value == 8) //Journée
        {
            StartCoroutine(LerpLight(_listGradient[1], _transitionGradientTime));
        }
        else if (value == 16) //couché du soleil
        {
            StartCoroutine(LerpLight(_listGradient[2], _transitionGradientTime));
        }
        else if (value == 18) //Nuit
        {
            StartCoroutine(LerpLight(_listGradient[3], _transitionGradientTime));
        }
        UpdateClockRotation();
    }

    private IEnumerator LerpLight(Gradient lightGradient, float time)
    {
        for (float i = 0; i < time; i += Time.deltaTime * _timeSpeed)
        {
            _globalLight.color = lightGradient.Evaluate(i / time);
            RenderSettings.fogColor = _globalLight.color;
            yield return null;
        }
    }

    public void SpeedTime()
    {
        if(_timeSpeed == 2) { _timeSpeed = 8; }
        else { _timeSpeed = 2; }
    }

    private void UpdateClockRotation()
    {
        float totalMinutes = Hours * 60 + Minutes;
        float rotationZ = -((totalMinutes / 1440f) * 360f); // 1440 = minutes dans une journée
        _clockImage.rotation = Quaternion.Euler(180, 0, rotationZ);
    }
}
