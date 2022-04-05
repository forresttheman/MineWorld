using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    [Range(0.0f, 1.0f)]
    public float time;
    [Tooltip("Length of day in seconds")]
    public float fullDayLength;

    [Tooltip("In a range between 0-1")]
    [Range(0.0f, 1.0f)]
    public float startTime = 0.4f;
    private float timeRate;
    public Vector3 noon;


    [Header("Sun")]
    public Light sun;
    public Gradient sunColor;
    public AnimationCurve sunIntensity;


    [Header("Moon")]
    public Light moon;
    public Gradient moonColor;
    public AnimationCurve moonIntensity;


    //other lighting
    [Header("Other Lighting")]
    public AnimationCurve lightingIntensityMultiplier;
    public AnimationCurve reflectionsIntensityMultiplier;

    // Start is called before the first frame update
    void Start()
    {
        timeRate = 1.0f / fullDayLength; //how much time we add every second
        time = startTime;
    }

    // Update is called once per frame
    void Update()
    {
        //increment time
        time += timeRate * Time.deltaTime;

        if (time >= 1.0f) {
            time = 0.0f;
        }

        //light rotation
        sun.transform.eulerAngles = (time - 0.25f) * noon * 4.0f; //as the sun rotates, the moon rottates at the opposite
        moon.transform.eulerAngles = (time - 0.75f) * noon * 4.0f;

        //light intensity
        sun.intensity = sunIntensity.Evaluate(time);
        moon.intensity = moonIntensity.Evaluate(time);

        // change colors
        sun.color = sunColor.Evaluate(time);
        moon.color = moonColor.Evaluate(time);

        // enable / disable sun
        if (sun.intensity == 0 && sun.gameObject.activeInHierarchy)
        {
            sun.gameObject.SetActive(false);
        }
        else if (sun.intensity > 0 && !sun.gameObject.activeInHierarchy) {
            sun.gameObject.SetActive(true);
        }

        // enable / disable moon
        if (moon.intensity == 0 && moon.gameObject.activeInHierarchy)
        {
            moon.gameObject.SetActive(false);
        }
        else if (moon.intensity > 0 && !moon.gameObject.activeInHierarchy)
        {
            moon.gameObject.SetActive(true);
        }

        //lighting and reflection intensity
        RenderSettings.ambientIntensity = lightingIntensityMultiplier.Evaluate(time);
        RenderSettings.reflectionIntensity = reflectionsIntensityMultiplier.Evaluate(time);
    }
}
