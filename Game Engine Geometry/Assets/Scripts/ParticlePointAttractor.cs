using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlePointAttractor : MonoBehaviour
{
    [SerializeField]
    ParticleSystem[] particleSystems = default;
    [SerializeField]
    float radius = 1;
    void Start()
    {
        
    }

    void Update()
    {
        //TODO: Figure out why particles are not being detected when they enter the radius
        for (int i = 0; i < particleSystems.Length; i++)
        {
            ParticleSystem.Particle[] particleArray = new ParticleSystem.Particle[particleSystems[i].particleCount];
            particleSystems[i].GetParticles(particleArray);

            for (int j = 0; j < particleArray.Length; j++)
            {
                if (Vector3.Distance(particleArray[i].position, transform.position) <= radius)
                {
                    Debug.Log("Entered field");
                }
                
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position, radius);
    }
}
