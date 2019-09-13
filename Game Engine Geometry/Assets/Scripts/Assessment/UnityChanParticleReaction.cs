using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanParticleReaction : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnParticleCollision(GameObject other)
    {
        Debug.Log("Collided with " + other.name);
    }
}
