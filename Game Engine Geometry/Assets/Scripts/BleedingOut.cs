using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class BleedingOut : MonoBehaviour
{
    [SerializeField]
    float maxHealth = 100;
    [SerializeField, Range(0, 100)]
    float health = 100;
    [SerializeField, Range(0, 100)]
    float blurStartPoint = 100;

    PostProcessVolume m_Volume;
    Vignette m_Vignette;

    void Start()
    {
        m_Vignette = ScriptableObject.CreateInstance<Vignette>();
        m_Vignette.enabled.Override(true);
        m_Vignette.intensity.Override(1f);

        m_Volume = PostProcessManager.instance.QuickVolume(gameObject.layer, 100f, m_Vignette);
    }

    void Update()
    {
        if (health <= blurStartPoint)
        {
            m_Vignette.intensity.value = Mathf.Abs(health / blurStartPoint - 1);
        }
        
    }
}
