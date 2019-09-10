using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlePointAttractor : MonoBehaviour
{
    [SerializeField]
    ParticleSystem[] particleSystems = default;
    [SerializeField]
    float radius = 1;
    [SerializeField]
    float intensity = 1;
    void Start()
    {
        
    }

    void Update()
    {
        for (int i = 0; i < particleSystems.Length; i++)
        {
            ParticleSystem.Particle[] particleArray = new ParticleSystem.Particle[particleSystems[i].particleCount];
            particleSystems[i].GetParticles(particleArray);

            for (int j = 0; j < particleArray.Length; j++)
            {
                //Vector3 particleWorldPosition = particleSystems[i].transform.TransformPoint(particleArray[j].position);
                float distance = Vector3.Distance(particleArray[j].position, transform.position);
                if (distance <= radius)
                {
                    Vector3 difference = transform.position - particleArray[j].position;
                    particleArray[j].velocity += difference * intensity;
                    //particleArray[j].position = new Vector3(particleArray[j].position.x, particleArray[j].position.y, -1);
                    particleArray[j].startColor = Color.green;
                }
                
            }
            particleSystems[i].SetParticles(particleArray);
        }
    }

    private void OnDrawGizmos()
    {
        //Gizmos.DrawSphere(transform.position, radius);
    }
}
