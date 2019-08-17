using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshFilter))]


public class VertexVisualizer : MonoBehaviour
{
    MeshRenderer mr;
    MeshFilter filter;
    [SerializeField]
    new bool enabled = true;
    
    void Start()
    {
        mr = GetComponent<MeshRenderer>();
        filter = GetComponent<MeshFilter>();
    }

    
    void Update()
    {
        
    }

    void OnDrawGizmos()
    {
        if (!Application.IsPlaying(gameObject) || filter.mesh == null || !enabled)
        {
            return;
        }
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        for (int i = 0; i < filter.mesh.vertexCount; i++)
        {
            Gizmos.DrawSphere(filter.mesh.vertices[i] + transform.position, 0.05f);
        }

    }
}
