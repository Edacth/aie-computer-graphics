using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class FadeTransition : MonoBehaviour
{
    [SerializeField]
    float transitionLength = 3;
    [SerializeField]
    float transitionTime = 0;
    float transitionProgress = 0;
    bool transitioning = false;
    bool fadingOut = true;

    PostProcessVolume m_Volume;
    ColorGrading m_colorGrading;
    void Start()
    {
        m_colorGrading = ScriptableObject.CreateInstance<ColorGrading>();
        m_colorGrading.enabled.Override(true);
        m_colorGrading.brightness.Override(0f);

        m_Volume = PostProcessManager.instance.QuickVolume(gameObject.layer, 1, m_colorGrading);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftBracket))
        {
            fadeOut();
        }
        if (Input.GetKeyDown(KeyCode.RightBracket))
        {
            fadeIn();
        }

        if (transitioning)
        {
            transitionTime += fadingOut ? Time.deltaTime : -Time.deltaTime;
            transitionProgress = transitionTime / transitionLength;
        }
        if (transitionTime >= transitionLength || transitionTime <= 0)
        {
            transitioning = false;
            
        }

        m_colorGrading.brightness.value = transitionProgress * -100;
    }

    void fadeOut()
    {
        transitioning = true;
        fadingOut = true;
        
    }

    void fadeIn()
    {
        transitioning = true;
        fadingOut = false;
    }

    void OnDestroy()
    {
        RuntimeUtilities.DestroyVolume(m_Volume, true, true);
    }
}
