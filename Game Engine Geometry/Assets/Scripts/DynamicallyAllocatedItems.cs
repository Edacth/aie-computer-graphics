using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DynamicallyAllocatedItems : MonoBehaviour
{
    [SerializeField]
    GameObject content = default;
    [SerializeField]
    ShopItem[] itemList = default;
    [SerializeField]
    GameObject prefab = default;
    void Start()
    {
        for (int i = 0; i < itemList.Length; i++)
        {
            GameObject newItem = Instantiate<GameObject>(prefab, content.transform);
            newItem.transform.GetChild(0).GetComponent<Text>().text = itemList[i].name;
            newItem.transform.position = new Vector3(0, 50 * i, 0);
        }
    }

    void Update()
    {
        
    }
}

[System.Serializable]
public class ShopItem
{
    public string name;
    public int price;

}
