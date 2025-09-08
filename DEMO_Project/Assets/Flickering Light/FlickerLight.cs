using UnityEngine;

public class FlickerLight : MonoBehaviour
{
    [SerializeField] AnimationCurve curve;
    [SerializeField] new Light light;
    [SerializeField] float time;
    [SerializeField] float maxCurveLength;

    private void Update()
    {
        time += Time.deltaTime;
        light.intensity = curve.Evaluate(time);
        if (time > maxCurveLength)
        {
            time = 0;
        }
    }
}
