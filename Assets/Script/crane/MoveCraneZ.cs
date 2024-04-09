using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCraneZ : MonoBehaviour
{
    public float speed = 5.0f;
    public float minZ = 4.5f;
    public float maxZ = 11.5f;
    public Transform target;
    private Rigidbody rb; 

    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
    }

    void FixedUpdate() 
    {
        float zInput = Input.GetAxis("zc"); 
        Vector3 moveDirection = new Vector3(0, 0, zInput);
        Vector3 newPosition = rb.position + moveDirection * speed * Time.fixedDeltaTime;
       
        newPosition.z = Mathf.Clamp(newPosition.z, minZ, maxZ);

        rb.MovePosition(new Vector3(target.position.x, rb.position.y, newPosition.z));
    }
}
