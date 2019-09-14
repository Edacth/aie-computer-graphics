using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanParticleReaction : MonoBehaviour
{
    ParticleSystem ps;
    [SerializeField]
    UnityChanScript _UnityChanScript;

    void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        
    }

    private void OnParticleCollision(GameObject other)
    {
        Debug.Log("Ouch! A " + other.name);
        _UnityChanScript.TriggerImpact();
    }
}
