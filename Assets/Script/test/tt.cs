using UnityEngine;

public class ArticulationMover : MonoBehaviour
{
    private ArticulationBody articulationBody;
    public float moveSpeed = 0.1f; // 控制移动速度

    void Start()
    {
        articulationBody = GetComponent<ArticulationBody>();
    }

    void Update()
    {
        ArticulationDrive drive = articulationBody.yDrive;

        if (Input.GetKey(KeyCode.W))
        {
            drive.target += moveSpeed; // 按 W 键时增加目标位置
        }
        else if (Input.GetKey(KeyCode.S))
        {
            drive.target -= moveSpeed; // 按 S 键时减少目标位置
        }

        articulationBody.yDrive = drive;
    }
}
