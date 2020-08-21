using UnityEngine;

public class Flashlight : MonoBehaviour
{
    [SerializeField] private Light _lightSource;
    private bool _isFlashlightLit;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (!_isFlashlightLit)
            {
                _lightSource.intensity = 5;
                _isFlashlightLit = true;
            }
            else
            {
                _lightSource.intensity = 0;
                _isFlashlightLit = false;
            }
        }
    }
}
