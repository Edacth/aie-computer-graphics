using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UnityChanUIScript : MonoBehaviour
{
    private float movementSpeed;
    [SerializeField]
    private Animator unityChanAnimator = default;
    [SerializeField]
    private DisplayItem[] itemList = default;
    [SerializeField]
    private TMPro.TMP_Dropdown dropdownObject = default;
    private int dropDownIndex = 0;
    private bool rotationEnabled = true;

    void Start()
    {
        for (int i = 0; i < itemList.Length; i++)
        {
            dropdownObject.options.Add(new TMPro.TMP_Dropdown.OptionData(itemList[i].name));
            GameObject obj = Instantiate<GameObject>(itemList[i].prefab, new Vector3(-0.767f, 1, -0.387f), Quaternion.identity);
            obj.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            if (i != 0)
            {
                obj.SetActive(false);
            }
            itemList[i].objectReference = obj;
        }
        dropdownObject.captionText.text = dropdownObject.options[0].text;
        
    }

    void Update()
    {
        if (rotationEnabled) { itemList[dropDownIndex].objectReference.transform.Rotate(Vector3.up, 1); }
        
    }

    public void OnSliderValueChanged(Slider slider)
    {
        movementSpeed = slider.value;
        unityChanAnimator.SetFloat("Move Speed", slider.value);
    }

    public void OnArmToggle(Toggle toggle)
    {
        unityChanAnimator.SetBool("Hand Raised", toggle.isOn);
    }

    public void OnJumpButtonPress()
    {
        unityChanAnimator.SetTrigger("Jump");
    }

    public void OnSlideButtonPress()
    {
        unityChanAnimator.SetTrigger("Slide");
    }

    public void OnImpactButtonPress()
    {
        unityChanAnimator.SetTrigger("Take Damage");
    }

    public void OnItemDropdownChange(TMPro.TMP_Dropdown dropdown)
    {
        dropDownIndex = dropdown.value;
        for (int i = 0; i < itemList.Length; i++)
        {
            itemList[i].objectReference.SetActive(i == dropDownIndex ? true : false);
        }
    }

    public void OnRotateToggle(Toggle toggle)
    {
        rotationEnabled = toggle.isOn;
    }
}

[System.Serializable]
public class DisplayItem
{
    public string name;
    public GameObject prefab;
    [HideInInspector]
    public GameObject objectReference;

}
