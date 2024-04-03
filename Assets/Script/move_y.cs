using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_y : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 5.0f; 
    public float minY = 1.5f; 
    public float maxY = 2.9f;  
    public Transform target; 



    // Update is called once per frame
    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");

        
        float newY = transform.position.y + verticalInput * speed * Time.deltaTime;

        
        newY = Mathf.Clamp(newY, minY, maxY);

        
        transform.position = new Vector3(target.position.x, newY, target.position.z);
        
    }
}
