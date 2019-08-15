using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Light))]
public class LightChanger : MonoBehaviour
{
    Light light;

    float targetIntensity;
    float transitionTime;

    void Start()
    {
        light = GetComponent<Light>();
    }

    void Update()
    {
        light.intensity =
    }
}
