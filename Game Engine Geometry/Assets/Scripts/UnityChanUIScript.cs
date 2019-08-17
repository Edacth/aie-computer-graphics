using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UnityChanUIScript : MonoBehaviour
{
    float movementSpeed;
    [SerializeField]
    Animator unityChanAnimator = default;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void OnSliderValueChanged(Slider slider)
    {
        movementSpeed = slider.value;
        unityChanAnimator.SetFloat("Move Speed", slider.value);
    }

}
