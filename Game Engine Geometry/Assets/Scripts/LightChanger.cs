using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Light))]
public class LightChanger : MonoBehaviour
{
    new Light light = default;

    [SerializeField]
    bool on = false;
    [SerializeField]
    float interp;

    [SerializeField]
    float onIntensity = default;
    [SerializeField]
    float offIntensity = default;
    float targetIntensity;
    float startingIntensity;
    [SerializeField]
    float transitionSpeed = default;


    void Start()
    {
        light = GetComponent<Light>();
        interp = 0;
    }

    void Update()
    {
        if (on)
        {
            targetIntensity = onIntensity;
            startingIntensity = light.intensity;
        }
        else
        {
            targetIntensity = offIntensity;
            startingIntensity = light.intensity;
        }

        if (targetIntensity >= interp)
        {
            interp += 0.1f * Time.deltaTime * transitionSpeed;
            light.intensity = offIntensity * (1 - interp) + onIntensity * interp;
        }
        else if (targetIntensity <= interp)
        {
            interp -= 0.1f * Time.deltaTime * transitionSpeed;
            light.intensity = offIntensity * (1 - interp) + onIntensity * interp;
        }

        
    }
}
