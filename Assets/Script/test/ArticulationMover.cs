using UnityEngine;

public class MoveXAxisJoint : MonoBehaviour
{
    public float range = 2.0f; // 移动范围
    public float speed = 1.0f; // 移动速度

    private ConfigurableJoint configurableJoint;
    private float startPositionX;
    private float targetPosition;

    void Start()
    {
        configurableJoint = GetComponent<ConfigurableJoint>();
        if (configurableJoint == null)
        {
            Debug.LogError("ConfigurableJoint component not found!");
            return;
        }

        startPositionX = transform.position.x;
        targetPosition = startPositionX;
    }

    void Update()
    {
        // 简单的来回移动逻辑
        if (Mathf.Abs(targetPosition - startPositionX) > range)
        {
            speed = -speed;
        }
        targetPosition += speed * Time.deltaTime;

        // 更新关节的目标位置
        SetTargetPositionX(targetPosition);
    }

    void SetTargetPositionX(float position)
    {
        var target = new Vector3(position - startPositionX, 0, 0);
        configurableJoint.targetPosition = target;
    }
}
