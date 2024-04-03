using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_x : MonoBehaviour
{

    public float speed = 5.0f; // 移动速度
    public float minX = -29f; // x轴移动的最小边界
    public float maxX = 29f;  // x轴移动的最大边界
    // Update is called once per frame
    void Update()
    {        
        float horizontalInput = Input.GetAxis("Horizontal");
     
        float newX = transform.position.x + horizontalInput * speed * Time.deltaTime;


        newX = Mathf.Clamp(newX, minX, maxX);

        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
    }
}   