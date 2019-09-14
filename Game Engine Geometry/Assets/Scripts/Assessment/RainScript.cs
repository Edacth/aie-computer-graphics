﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainScript : MonoBehaviour
{
    [SerializeField]
    ParticleSystem particleSystem = default;

    void Start()
    {
        
    }

    public void StartRain()
    {
        particleSystem.Play();
    }

    public void StopRain()
    {
        particleSystem.Stop();
    }
}