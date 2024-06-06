using System.Collections;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField] private Texture2D _skyboxNuit;
    [SerializeField] private Texture2D _skyboxDebutSoleil;
    [SerializeField] private Texture2D _skyboxJour;
    [SerializeField] private Texture2D _skyboxCouchéSoleil;

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
    public void Update()
    {
        tempSecond += Time.deltaTime;

        if (tempSecond >= 1)
        {
            Minutes += 1;
            tempSecond = 0;
        }
    }

    private void OnMinutesChange(int value)
    {
        globalLight.transform.Rotate(Vector3.up, 0.1f / (1440f / 4f) * 360f, Space.World);
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
            //StartCoroutine(LerpSkybox(_skyboxNuit, _skyboxDebutSoleil, 10f));
            StartCoroutine(LerpLight(graddientNightToSunrise, 10f));
        }
        else if (value == 2)
        {
            //StartCoroutine(LerpSkybox(_skyboxDebutSoleil, _skyboxJour, 10f));
            StartCoroutine(LerpLight(graddientSunriseToDay, 10f));
        }
        else if (value == 5)
        {
            //StartCoroutine(LerpSkybox(_skyboxJour, _skyboxCouchéSoleil, 10f));
            StartCoroutine(LerpLight(graddientDayToSunset, 10f));
        }
        else if (value == 6)
        {
            //StartCoroutine(LerpSkybox(_skyboxCouchéSoleil, _skyboxNuit, 10f));
            StartCoroutine(LerpLight(graddientSunsetToNight, 10f));
        }
    }

    private IEnumerator LerpSkybox(Texture2D a, Texture2D b, float time)
    {
        RenderSettings.skybox.SetTexture("_Texture1", a);
        RenderSettings.skybox.SetTexture("_Texture2", b);
        RenderSettings.skybox.SetFloat("_Blend", 0);
        for (float i = 0; i < time; i += Time.deltaTime)
        {
            RenderSettings.skybox.SetFloat("_Blend", i / time);
            yield return null;
        }
        RenderSettings.skybox.SetTexture("_Texture1", b);
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
