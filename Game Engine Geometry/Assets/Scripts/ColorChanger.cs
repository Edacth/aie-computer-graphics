using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshFilter))]

public class ColorChanger : MonoBehaviour
{
    MeshRenderer mr;
    Material mat;

    [SerializeField] [Range(0,1)]
    float r, g, b;
    Color newColor;

    [SerializeField]
    Texture[] textures= null;
    [SerializeField]
    int textureIndex = default;
    int cachedTextureIndex;

    void Start()
    {
        mr = GetComponent<MeshRenderer>();
        mat = mr.material;
        r = mat.color.r;
        g = mat.color.g;
        b = mat.color.b;

        cachedTextureIndex = textureIndex;
        mat.mainTexture = textures[textureIndex];
    }

    void Update()
    {
        newColor = new Color(r, g, b);
        mat.color = newColor;

        if (textureIndex != cachedTextureIndex && textureIndex < textures.Length && textureIndex >= 0)
        {
            mat.mainTexture = textures[textureIndex];
            Debug.Log("Changed Texture");
            cachedTextureIndex = textureIndex;
        }
    }
}
