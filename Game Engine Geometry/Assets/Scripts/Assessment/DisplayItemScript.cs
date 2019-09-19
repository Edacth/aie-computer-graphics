using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayItemScript : MonoBehaviour
{
    [SerializeField]
    private DisplayItem[] itemList = default;
    private bool rotationEnabled = true;
    int itemIndex = 0;

    void Start()
    {
        // Instantiate objects and hide the unselected ones
        for (int i = 0; i < itemList.Length; i++)
        {
            GameObject obj = Instantiate<GameObject>(itemList[i].prefab, new Vector3(-0.767f, 1, -0.387f), Quaternion.identity);
            obj.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            if (i != 0)
            {
                obj.SetActive(false);
            }
            itemList[i].objectReference = obj;
        }
    }

    void Update()
    {
        if (rotationEnabled) { itemList[itemIndex].objectReference.transform.Rotate(Vector3.up, 60 * Time.deltaTime); }
    }

    public void SetSelectedItem(int _itemIndex)
    {
        itemIndex = _itemIndex;
        for (int i = 0; i < itemList.Length; i++)
        {
            itemList[i].objectReference.SetActive(i == itemIndex ? true : false);
        }
    }

    public void SetRotationEnabled(bool enabled)
    {
        rotationEnabled = enabled;
    }

    public DisplayItem[] getItemList()
    {
        return itemList;
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