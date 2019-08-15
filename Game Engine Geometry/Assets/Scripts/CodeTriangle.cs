using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeTriangle : MonoBehaviour
{
    [SerializeField]
    string shape;
    private Mesh customMesh;
    void Start()
    {
        var mesh = new Mesh();
        switch (shape)
        {
            #region quad
            case "quad":
                {
                    // Vertices
                    // locations of vertices
                    var verts = new Vector3[4];

                    verts[0] = new Vector3(0, 0, 0);
                    verts[1] = new Vector3(0, 1, 0);
                    verts[2] = new Vector3(1, 0, 0);
                    verts[3] = new Vector3(1, 1, 0);

                    mesh.vertices = verts;

                    // Indices
                    // determines which vertices make up an individual triangle
                    //
                    // this should always be a multiple of three
                    //
                    // each triangle should be specified in _clock-wise_ order
                    var indices = new int[6];

                    indices[0] = 0;
                    indices[1] = 1;
                    indices[2] = 2;
                    indices[3] = 1;
                    indices[4] = 3;
                    indices[5] = 2;

                    mesh.triangles = indices;

                    // Normals
                    // describes how light bounces off the surface (at the vertex level)
                    //
                    // note that this data is interpolated across the surface of the triangle
                    var norms = new Vector3[4];

                    norms[0] = -Vector3.forward;
                    norms[1] = -Vector3.forward;
                    norms[2] = -Vector3.forward;
                    norms[3] = -Vector3.forward;

                    mesh.normals = norms;

                    // UVs, STs
                    // defines how textures are mapped onto the surface
                    var UVs = new Vector2[4];

                    UVs[0] = new Vector2(0, 0);
                    UVs[1] = new Vector2(0, 1);
                    UVs[2] = new Vector2(1, 0);
                    UVs[3] = new Vector2(1, 1);

                    mesh.uv = UVs;

                    var filter = GetComponent<MeshFilter>();
                    filter.mesh = mesh;
                    customMesh = mesh;
                    break;
                }
            #endregion
            case "pentagon":
                {
                    var verts = new Vector3[6];

                    verts[0] = new Vector3(0, 0, 0);
                    verts[1] = new Vector3(0.5f, -1, 0);
                    verts[2] = new Vector3(1, 0, 0);
                    verts[3] = new Vector3(0, 1, 0);
                    verts[4] = new Vector3(-1, 0, 0);
                    verts[5] = new Vector3(-0.5f, -1, 0);

                    mesh.vertices = verts;

                    var indicies = new int[12];

                    indicies[0] = 0;
                    indicies[1] = 1;
                    indicies[2] = 2;
                    indicies[3] = 2;
                    indicies[4] = 3;
                    indicies[5] = 4;
                    indicies[6] = 0;
                    indicies[7] = 4;
                    indicies[8] = 5;
                    indicies[9] = 0;
                    indicies[10] = 5;
                    indicies[11] = 1;

                    mesh.triangles = indicies;

                    var norms = new Vector3[6];

                    norms[0] = -Vector3.forward;
                    norms[1] = -Vector3.forward;
                    norms[2] = -Vector3.forward;
                    norms[3] = -Vector3.forward;
                    norms[4] = -Vector3.forward;
                    norms[5] = -Vector3.forward;

                    mesh.normals = norms;

                    // UVs, STs
                    // defines how textures are mapped onto the surface
                    var UVs = new Vector2[6];

                    UVs[0] = new Vector2(0, 0);
                    UVs[1] = new Vector2(0.5f, -1);
                    UVs[2] = new Vector2(1, 0);
                    UVs[3] = new Vector2(0, 1);
                    UVs[4] = new Vector2(-1, 0);
                    UVs[5] = new Vector2(-0.5f, -1);

                    mesh.uv = UVs;

                    var filter = GetComponent<MeshFilter>();
                    filter.mesh = mesh;
                    customMesh = mesh;
                    break;
                }
            default:
                break;
        }
        
        



        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnDestroy()
    {
        if (customMesh != null)
        {
            Destroy(customMesh);
        }
    }
}
