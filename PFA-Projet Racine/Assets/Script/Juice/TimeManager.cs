using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class TimeManager : MonoBehaviour
{
    [SerializeField]
    private List<VisualEffect> _papillon;
    [SerializeField]
    private VisualEffect _luciole;
    [SerializeField]
    private AudioClip _hiboux;
    [SerializeField]
    private AudioClip _oiseaux;
    [SerializeField]
    private AudioSource _ambiance;

    [SerializeField] private Gradient graddientNightToSunrise;
    [SerializeField] private Gradient graddientSunriseToDay;
    [SerializeField] private Gradient graddientDayToSunset;
    [SerializeField] private Gradient graddientSunsetToNight;

    [SerializeField] private Light globalLight;

    [SerializeField] private int minutes = 59;

    public int Minutes
    { get { return minutes; } set { minutes = value; OnMinutesChange(value); } }

    private int hours = 1;
    public int Hours
    { get { return hours; } set { hours = value; OnHoursChange(value); } }

    [SerializeField] private int days;

    public int Days
    { get { return days; } set { days = value; } }

    private float tempSecond;

    private void Start()
    {
        Time.timeScale = 1

            ;
    }
    public void FixedUpdate()
    {
        globalLight.transform.Rotate(Vector3.up, 0.001f / (1440f / 4f) * 360f, Space.World);
        tempSecond += Time.deltaTime;

        if (tempSecond >= 1)
        {
            Minutes += 1;
            tempSecond = 0;
        }
    }

    private void OnMinutesChange(int value)
    {
        if (value >= 60)
        {
            Hours++;
            minutes = 0;
        }
        if (Hours >= 9)
        {
            Hours = 0;
            Days++;
        }
    }

    private void OnHoursChange(int value)
    {
        if (value == 1)
        {
            _luciole.gameObject.SetActive(false);
            StartCoroutine(LerpLight(graddientNightToSunrise, 10f));
        }
        else if (value == 2)
        {
            _ambiance.clip = _oiseaux;
            _ambiance.Play();
            foreach(VisualEffect obj in _papillon)
            {
                obj.Play();
                obj.gameObject.SetActive(true);
            }
            StartCoroutine(LerpLight(graddientSunriseToDay, 10f));
        }
        else if (value == 5)
        {
            Debug.Log("jour");
            StartCoroutine(LerpLight(graddientDayToSunset, 10f));
        }
        else if (value == 6)
        {
            //_ambiance.clip = _hiboux;
            //_ambiance.Play();
            foreach (VisualEffect obj in _papillon)
            {
                obj.gameObject.SetActive(false);
            }
            _luciole.gameObject.SetActive(true);
            _luciole.Play();
            Debug.Log("jour");
            StartCoroutine(LerpLight(graddientSunsetToNight, 10f));
        }
    }

    private IEnumerator LerpLight(Gradient lightGradient, float time)
    {
        for (float i = 0; i < time; i += Time.deltaTime)
        {
            globalLight.color = lightGradient.Evaluate(i / time);
            RenderSettings.fogColor = globalLight.color;
            yield return null;
        }
    }
}
