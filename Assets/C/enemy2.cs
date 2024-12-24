using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy2 : MonoBehaviour
{
    public Transform cameraTransform;  


    void Start()
    {
       
        FaceCamera();
    }

 
    void Update()
    {
       
        FaceCamera();
    }

    
    void FaceCamera()
    {
       
        Vector3 direction = cameraTransform.position - transform.position;
        direction.y = 0;  

        
        Quaternion targetRotation = Quaternion.LookRotation(direction);

       
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5f);
    }
}