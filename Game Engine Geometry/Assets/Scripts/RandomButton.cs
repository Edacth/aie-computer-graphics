using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class RandomButton : MonoBehaviour
{
    Button button;
    void Start()
    {
        button = GetComponent<Button>();

        int rand = Random.Range(0, 2);
        switch (rand)
        {
            case 0:
                Debug.Log(0);
                button.onClick.AddListener(delegate { TurnRed(); });
                break;
            case 1:
                Debug.Log(1);
                button.onClick.AddListener(delegate { TurnGreen(); });
                break;
            case 2:
                Debug.Log(2);
                button.onClick.AddListener(delegate { TurnBlue(); });
                break;
            default:
                break;
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TurnRed()
    {
        ColorBlock colorBlock = button.colors;
        colorBlock.highlightedColor = Color.red;
        button.colors = colorBlock;
    }

    void TurnGreen()
    {
        ColorBlock colorBlock = button.colors;
        colorBlock.highlightedColor = Color.green;
        button.colors = colorBlock;
    }

    void TurnBlue()
    {
        ColorBlock colorBlock = button.colors;
        colorBlock.highlightedColor = Color.blue;
        button.colors = colorBlock;
    }
}
