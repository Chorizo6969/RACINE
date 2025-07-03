using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script qui gère la journée dans le jeu (cycle jour/nuit)
/// </summary>
public class TimeInGame : MonoBehaviour
{
    #region Variable

    [Header("Light and color")]
    [SerializeField] private List<Gradient> _listGradient = new(); //Nuit, Levée du soleil, aprem, couché de soleil
    [SerializeField] private Light _globalLight;
    [SerializeField][Tooltip("Temps en s que mets la transition de couleur du gardient (par défaut 10s)")] private float _transitionGradientTime = 10;
    public int TimeSpeed = 2;


    [Header("Timer Settings")]
    [SerializeField] private int days;
    public int Days { get { return days; } set { days = value; } }


    private int _minutes = 59;
    public int Minutes { get { return _minutes; } set { _minutes = value; OnMinutesChange(value); } }


    private int _hours = 5;
    public int Hours { get { return _hours; } set { _hours = value; OnHoursChange(value); } }

    private float _second;

    [Header("Others")]
    [SerializeField] private TimerUI _timerUI;

    #region Event
    public event Action OnStartWork;
    public event Action OnStartChomage;
    public event Action OnStartDiscuss;
    public event Action OnStartSleep;
    #endregion

    #endregion

    #region Singleton
    public static TimeInGame Instance;
    private void Awake() { Instance = this; }
    #endregion

    public void FixedUpdate()
    {
        _globalLight.transform.Rotate(Vector3.up, 0.001f / (1440f / 4f) * 360f, Space.World);
        _second += Time.deltaTime * TimeSpeed;

        if (_second >= 1)
        {
            Minutes += 1;
            _second = 0;
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
        _timerUI.UpdateClockRotation();
    }

    private void OnHoursChange(int value)
    {
        _timerUI.ChangeUIHours(value.ToString() + "h");
        if (value == 6) //Levée du soleil
        {
            StartCoroutine(LerpLight(_listGradient[0], _transitionGradientTime)); //TO DO : La transition est fixe et pas proportionelle à la vitesse du temps/jeu
            OnStartWork.Invoke();
        }
        else if (value == 8) //Journée
        {
            StartCoroutine(LerpLight(_listGradient[1], _transitionGradientTime));
        }
        else if (value == 11)
        {
            OnStartChomage.Invoke();
        }
        else if (value == 16) //couché du soleil
        {
            StartCoroutine(LerpLight(_listGradient[2], _transitionGradientTime));
            OnStartDiscuss.Invoke();
        }
        else if (value == 18) //Nuit
        {
            StartCoroutine(LerpLight(_listGradient[3], _transitionGradientTime));
            OnStartSleep.Invoke();
        }
        _timerUI.UpdateClockRotation();
    }

    private IEnumerator LerpLight(Gradient lightGradient, float time)
    {
        for (float i = 0; i < time; i += Time.deltaTime * TimeSpeed)
        {
            _globalLight.color = lightGradient.Evaluate(i / time);
            RenderSettings.fogColor = _globalLight.color;
            yield return null;
        }
    }
}
