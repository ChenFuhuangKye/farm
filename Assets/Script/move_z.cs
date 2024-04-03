using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_z : MonoBehaviour
{
    public float speed = 5.0f; 
    public float minZ = 4.5f; 
    public float maxZ = 11.5f;  
    public Transform target; 


    // Update is called once per frame
    void Update()
    {
        float zInput = Input.GetAxis("zc");

        float newZ = transform.position.z + zInput * speed * Time.deltaTime;

        newZ = Mathf.Clamp(newZ, minZ, maxZ); 
        
        transform.position = new Vector3(target.position.x, transform.position.y, newZ);
    
    }
}
