using UnityEngine;

public class MidObjectSpawner : MonoBehaviour
{
    public Transform startPoint; // 起点物体
    public Transform endPoint; // 终点物体
    public GameObject prefabToSpawn; // 要生成的Prefab
    private GameObject spawnedObject; // 生成的对象实例

    void Update()
    {
        if (spawnedObject == null)
        {
            // 实例化Prefab
            spawnedObject = Instantiate(prefabToSpawn, Vector3.zero, Quaternion.identity);
        }

        // 计算中点位置
        Vector3 midPoint = (startPoint.position + endPoint.position) / 2;
        spawnedObject.transform.position = midPoint;

        // 调整Prefab的长度使其填满两个物体之间的空间
        float distance = Vector3.Distance(startPoint.position, endPoint.position)/2;
        spawnedObject.transform.localScale = new Vector3(spawnedObject.transform.localScale.x, distance, spawnedObject.transform.localScale.z);

        // 调整Prefab的旋转使其朝向两个物体
        spawnedObject.transform.LookAt(endPoint.position);
        // 因为LookAt会影响所有轴向的旋转，我们可能需要调整以保持Prefab的朝向和旋转
        spawnedObject.transform.rotation = Quaternion.Euler(0, spawnedObject.transform.rotation.eulerAngles.y, 0);
    }
}
