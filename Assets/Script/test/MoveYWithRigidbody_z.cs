using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveZWithRigidbody_z : MonoBehaviour
{
    public float speed = 5.0f;
    public float minZ = 4.5f;
    public float maxZ = 11.5f;
    public Transform target;

    private Rigidbody rb; // 用于存储 Rigidbody 的引用

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // 获取 Rigidbody 组件
    }

    void FixedUpdate() // 在 FixedUpdate 中处理物理相关的更新
    {
        float zInput = Input.GetAxis("zc"); // 确保在您的输入设置中有一个名为 "zc" 的轴
        Vector3 moveDirection = new Vector3(0, 0, zInput);
        Vector3 newPosition = rb.position + moveDirection * speed * Time.fixedDeltaTime;

        // 限制 z 轴上的移动范围
        newPosition.z = Mathf.Clamp(newPosition.z, minZ, maxZ);

        // 更新物体的位置，保持 x 和 y 轴上的位置与 target 对象一致
        rb.MovePosition(new Vector3(target.position.x, rb.position.y, newPosition.z));
    }
}
