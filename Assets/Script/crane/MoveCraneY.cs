using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCraneY : MonoBehaviour
{
    public float speed = 0.25f;
    public float minY = 0f; 
    public float maxY = 2.9f; 
    public Transform target;

    private Rigidbody rb; 
    public float moveY = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (moveY != 0f)
        {
            Vector3 localPos = gameObject.transform.localPosition;
            Vector3 moveDirection = new(0, moveY, 0);
            Vector3 newPosition = localPos + speed * Time.fixedDeltaTime * moveDirection;
            newPosition.y = Mathf.Clamp(newPosition.y, minY, maxY);
            gameObject.transform.localPosition = new(target.localPosition.x, newPosition.y, target.localPosition.z);
        }
        else
        {
            rb.position = new Vector3(target.position.x, rb.position.y, target.position.z);
        }
    }
}
