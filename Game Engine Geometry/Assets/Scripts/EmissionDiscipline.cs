using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmissionDiscipline : MonoBehaviour
{
    ParticleSystem particleSystem;
    ParticleSystem.TriggerModule trigger;
    [SerializeField]
    bool emitterEnabled = false;
    [SerializeField]
    float emissionDelay = 1;
    float timeSinceEmit = 0;
    void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
        trigger = particleSystem.trigger;


        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            emitterEnabled = true;
        }
        else if (Input.GetKeyUp(KeyCode.R))
        {
            emitterEnabled = false;
        }

        if (emitterEnabled && timeSinceEmit >= emissionDelay)
        {
            
            particleSystem.Emit(1);
            timeSinceEmit = 0;

            ParticleSystem.Particle[] particleArray = new ParticleSystem.Particle[particleSystem.particleCount];
            particleSystem.GetParticles(particleArray);

            //for (int i = 0; i < particleArray.Length; i++)
            //{
            //    particleArray[i].startColor = Color.red;
            //}
            //ParticleSystem.Particle[] particleTemplate = new ParticleSystem.Particle[1];
            //particleTemplate[0].startColor = Color.red;
            particleArray[particleArray.Length-1].startColor = Color.red;
            particleSystem.SetParticles(particleArray, particleArray.Length, 0);
        }
        timeSinceEmit += Time.deltaTime;
    }

    private void OnParticleCollision(GameObject other)
    {
        Debug.Log("Collided with " + other.name);
    }
}
