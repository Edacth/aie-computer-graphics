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
                    indicies[1] = 5;
                    indicies[2] = 4;
                    indicies[3] = 4;
                    indicies[4] = 3;
                    indicies[5] = 2;
                    indicies[6] = 0;
                    indicies[7] = 2;
                    indicies[8] = 1;
                    indicies[9] = 0;
                    indicies[10] = 1;
                    indicies[11] = 5;

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
            #region cube
            case "cube":
                
                {
                    var verts = new Vector3[24];

                    //Front
                    verts[0] = new Vector3(-1, -1, -1);
                    verts[1] = new Vector3(-1, 1, -1);
                    verts[2] = new Vector3(1, 1, -1);
                    verts[3] = new Vector3(1, -1, -1);

                    //Right
                    verts[4] = new Vector3(1, -1, -1);
                    verts[5] = new Vector3(1, 1, -1);
                    verts[6] = new Vector3(1, 1, 1);
                    verts[7] = new Vector3(1, -1, 1);

                    //Back
                    verts[8] = new Vector3(1, -1, 1);
                    verts[9] = new Vector3(1, 1, 1);
                    verts[10] = new Vector3(-1, 1, 1);
                    verts[11] = new Vector3(-1, -1, 1);

                    //Left
                    verts[12] = new Vector3(-1, -1, 1);
                    verts[13] = new Vector3(-1, 1, 1);
                    verts[14] = new Vector3(-1, 1, -1);
                    verts[15] = new Vector3(-1, -1, -1);

                    //Bottom
                    verts[16] = new Vector3(-1, -1, 1);
                    verts[17] = new Vector3(-1, -1, -1);
                    verts[18] = new Vector3(1, -1, -1);
                    verts[19] = new Vector3(1, -1, 1);

                    //top
                    verts[20] = new Vector3(-1, 1, -1);
                    verts[21] = new Vector3(-1, 1, 1);
                    verts[22] = new Vector3(1, 1, 1);
                    verts[23] = new Vector3(1, 1, -1);

                    mesh.vertices = verts;

                    var indicies = new int[36];

                    //Front
                    indicies[0] = 0;
                    indicies[1] = 1;
                    indicies[2] = 3;
                    indicies[3] = 1;
                    indicies[4] = 2;
                    indicies[5] = 3;

                    //Right
                    indicies[6] = 4;
                    indicies[7] = 5;
                    indicies[8] = 7;
                    indicies[9] = 5;
                    indicies[10] = 6;
                    indicies[11] = 7;

                    //Back
                    indicies[12] = 8;
                    indicies[13] = 9;
                    indicies[14] = 11;
                    indicies[15] = 9;
                    indicies[16] = 10;
                    indicies[17] = 11;

                    //Left
                    indicies[18] = 12;
                    indicies[19] = 13;
                    indicies[20] = 15;
                    indicies[21] = 13;
                    indicies[22] = 14;
                    indicies[23] = 15;

                    //Bottom
                    indicies[24] = 16;
                    indicies[25] = 17;
                    indicies[26] = 19;
                    indicies[27] = 17;
                    indicies[28] = 18;
                    indicies[29] = 19;

                    //Top
                    indicies[30] = 20;
                    indicies[31] = 21;
                    indicies[32] = 23;
                    indicies[33] = 21;
                    indicies[34] = 22;
                    indicies[35] = 23;

                    mesh.triangles = indicies;

                    var norms = new Vector3[24];

                    //Front
                    norms[0] = -Vector3.forward;
                    norms[1] = -Vector3.forward;
                    norms[2] = -Vector3.forward;
                    norms[3] = -Vector3.forward;

                    //Right
                    norms[4] = Vector3.right;
                    norms[5] = Vector3.right;
                    norms[6] = Vector3.right;
                    norms[7] = Vector3.right;

                    //Back
                    norms[8] = Vector3.forward;
                    norms[9] = Vector3.forward;
                    norms[10] = Vector3.forward;
                    norms[11] = Vector3.forward;

                    //Left
                    norms[12] = -Vector3.right;
                    norms[13] = -Vector3.right;
                    norms[14] = -Vector3.right;
                    norms[15] = -Vector3.right;

                    //Bottom
                    norms[16] = Vector3.down;
                    norms[17] = Vector3.down;
                    norms[18] = Vector3.down;
                    norms[19] = Vector3.down;

                    //Bottom
                    norms[20] = Vector3.up;
                    norms[21] = Vector3.up;
                    norms[22] = Vector3.up;
                    norms[23] = Vector3.up;

                    mesh.normals = norms;

                    var UVs = new Vector2[24];

                    //Front
                    UVs[0] = new Vector2(0, 0);
                    UVs[1] = new Vector2(0, 1);
                    UVs[2] = new Vector2(1, 1);
                    UVs[3] = new Vector2(1, 0);

                    //Right
                    UVs[4] = new Vector2(0, 0);
                    UVs[5] = new Vector2(0, 1);
                    UVs[6] = new Vector2(1, 1);
                    UVs[7] = new Vector2(1, 0);

                    //Back
                    UVs[8] = new Vector2(0, 0);
                    UVs[9] = new Vector2(0, 1);
                    UVs[10] = new Vector2(1, 1);
                    UVs[11] = new Vector2(1, 0);

                    //Left
                    UVs[12] = new Vector2(0, 0);
                    UVs[13] = new Vector2(0, 1);
                    UVs[14] = new Vector2(1, 1);
                    UVs[15] = new Vector2(1, 0);

                    //Bottom
                    UVs[16] = new Vector2(0, 0);
                    UVs[17] = new Vector2(0, 1);
                    UVs[18] = new Vector2(1, 1);
                    UVs[19] = new Vector2(1, 0);

                    //Top
                    UVs[20] = new Vector2(0, 0);
                    UVs[21] = new Vector2(0, 1);
                    UVs[22] = new Vector2(1, 1);
                    UVs[23] = new Vector2(1, 0);

                    mesh.uv = UVs;

                    var filter = GetComponent<MeshFilter>();
                    filter.mesh = mesh;
                    customMesh = mesh;
                    break;
                }
            default:
                break;
                #endregion
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
