using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCraneY : MonoBehaviour
{
    public float speed = 0.25f;
    public float minY = 0f; 
    public float maxY = 2.9f; 
    public Transform target;
    public float mass = 55f;

    private Rigidbody rb; 
    private Vector3 prePos;
    public float moveY=0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
        rb.useGravity = true; 
        prePos = transform.position;
        
    }

    void FixedUpdate()
    {
        

        if (moveY != 0f)
        {   
            float gravityCompensation = Mathf.Abs(Physics.gravity.y) * mass + moveY * speed;       
            rb.AddForce(new Vector3(0, gravityCompensation, 0), ForceMode.Force);
            prePos = transform.position;
        }
        else
        {
            float gravityCompensation;
           
            if (transform.position.y > prePos.y)
            {
                gravityCompensation = Mathf.Abs(Physics.gravity.y) * mass;                
            }
            else
            {
                gravityCompensation = Mathf.Abs(Physics.gravity.y) * (mass+1);            
            }                     
            rb.AddForce(new Vector3(0, gravityCompensation, 0), ForceMode.Force);            
        }

        rb.velocity = new Vector3(0, Mathf.Clamp(rb.velocity.y, minY, maxY), 0);

        rb.position = new Vector3(target.position.x, rb.position.y, target.position.z);
    }
}
