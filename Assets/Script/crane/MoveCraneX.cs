using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCraneX : MonoBehaviour
{
    public float speed = 5.0f;
    public float minX = -29f;
    public float maxX = 29f;

    private Rigidbody rb;
    public float moveX=0f;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
    }

    void FixedUpdate() 
    {
        Vector3 moveDirection = new Vector3(moveX, 0, 0);
        Vector3 newPosition = rb.position + moveDirection * speed * Time.fixedDeltaTime;
        
        newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);

        rb.MovePosition(newPosition);
    }
}
