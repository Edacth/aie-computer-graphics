using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIScript : MonoBehaviour
{
    DisplayItemScript _DisplayItemScript;
    UnityChanScript _UnityChanScript;
    
    [SerializeField]
    private TMPro.TMP_Dropdown dropdownObject = default;

    void Start()
    {
        _DisplayItemScript = GetComponent<DisplayItemScript>();
        _UnityChanScript = GetComponent<UnityChanScript>();

        for (int i = 0; i < _DisplayItemScript.getItemList().Length; i++)
        {
            dropdownObject.options.Add(new TMPro.TMP_Dropdown.OptionData(_DisplayItemScript.getItemList()[i].name));
        }
        dropdownObject.captionText.text = dropdownObject.options[0].text; 
    }

    public void OnSliderValueChanged(Slider slider)
    {
        _UnityChanScript.SetMovementSpeed(slider.value);
    }

    public void OnArmToggle(Toggle toggle)
    {
        _UnityChanScript.SetArmRaised( toggle.isOn);
    }

    public void OnJumpButtonPress()
    {
        _UnityChanScript.TriggerJump();
    }

    public void OnSlideButtonPress()
    {
        _UnityChanScript.TriggerSlide();
    }

    public void OnImpactButtonPress()
    {
        _UnityChanScript.TriggerImpact();
    }

    public void OnItemDropdownChange(TMPro.TMP_Dropdown dropdown)
    {
        _DisplayItemScript.SetSelectedItem(dropdown.value);
    }

    public void OnRotateToggle(Toggle toggle)
    {
        _DisplayItemScript.SetRotationEnabled(toggle.isOn);
    }
}