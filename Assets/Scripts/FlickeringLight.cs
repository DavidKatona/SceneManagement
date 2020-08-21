using System.Collections;
using UnityEngine;

public class FlickeringLight : MonoBehaviour
{
    private Light _lightSource;
    [SerializeField] private float _lightSourceDurationOn;
    [SerializeField] private float _lightSourceDurationOff;
    [SerializeField] private bool _startLit;
    private bool _isFlickering;

    private void Awake()
    {
        _lightSource = GetComponent<Light>();

        float startingIntensity = (_startLit) ? _lightSource.intensity = 1 : _lightSource.intensity = 0;
        _lightSource.intensity = startingIntensity;
    }

    void Update()
    {
        if (!_isFlickering)
        {
            StartCoroutine(Flicker(_lightSourceDurationOn, _lightSourceDurationOff));
        }
    }

    private IEnumerator Flicker(float durationOn, float durationOff)
    {
        _isFlickering = true;
        yield return new WaitForSeconds(durationOn);

        _lightSource.intensity = 0;

        yield return new WaitForSeconds(durationOff);
        _lightSource.intensity = 1;
        _isFlickering = false;
    }
}
