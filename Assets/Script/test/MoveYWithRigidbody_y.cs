using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveYWithRigidbody_y : MonoBehaviour
{
    public float speed = 5.0f; // 控制移动速度
    public float minY = 1.5f; // Y轴的最小值
    public float maxY = 2.9f; // Y轴的最大值
    public Transform target; // 目标对象，用于定位X和Z轴的位置

    private Rigidbody rb; // 用于存储 Rigidbody 的引用

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // 获取 Rigidbody 组件
    }

    void FixedUpdate() // 在 FixedUpdate 中处理物理相关的更新
    {
        float verticalInput = Input.GetAxis("Vertical"); // 获取垂直输入
        Vector3 moveDirection = new Vector3(0, verticalInput, 0); // 根据输入计算移动方向
        Vector3 newPosition = rb.position + moveDirection * speed * Time.fixedDeltaTime; // 计算新位置

        // 限制 y 轴上的移动范围
        newPosition.y = Mathf.Clamp(newPosition.y, minY, maxY);

        // 更新物体的位置，保持 x 和 z 轴上的位置与 target 对象一致
        rb.MovePosition(new Vector3(target.position.x, newPosition.y, target.position.z));
    }
}
