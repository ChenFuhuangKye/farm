using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class trangle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        MeshFilter meshFilter = GetComponent<MeshFilter>();
        Mesh mesh = new Mesh();
        meshFilter.mesh = mesh;

        // 頂點
        Vector3[] vertices = new Vector3[]
        {
            new Vector3(0, 0, 0), // 前面的頂點
            new Vector3(0, -1, 4), // 前面的左下角
            new Vector3(0, -1, -4), // 前面的右下角
            new Vector3(0.01f, 0, 0), // 後面的頂點
            new Vector3(0.01f, -1, 4), // 後面的左下角
            new Vector3(0.01f, -1, -4) // 後面的右下角
        };

        // 三角面
        int[] triangles = new int[]
        {
            0, 2, 1, // 前面
            3, 4, 5, // 後面
            0, 3, 5, 0, 5, 2, // 右側面
            0, 1, 4, 0, 4, 3, // 左側面
            1, 2, 5, 1, 5, 4  // 底面
        };

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals(); // 這有助於正確渲染燈光和陰影
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
