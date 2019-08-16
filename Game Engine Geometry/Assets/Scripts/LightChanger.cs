using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Light))]
public class LightChanger : MonoBehaviour
{
    Light light;

    [SerializeField]
    bool on = false;
    [SerializeField]
    float interp;

    [SerializeField]
    float onIntensity;
    [SerializeField]
    float offIntensity;
    float targetIntensity;
    float startingIntensity;
    [SerializeField]
    float transitionSpeed;


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
