using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleMover : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Transform target;
    public Light lightA;  
    private bool isInLightA = false; 
    void Start()
    {
        GameObject targetObject = GameObject.Find("Camera");
        if (targetObject != null)
        {
            target = targetObject.transform;
        }
    }

    void Update()
    {
        if (lightA != null)
        {
            CheckIfInLightA();  
        }

        if (target != null && !isInLightA) 
        {
            MoveTowardsTarget(); 
        }
    }

 
    void CheckIfInLightA()
    {
        Vector3 directionToLight = transform.position - lightA.transform.position;
        RaycastHit hit;

        
        if (Physics.Raycast(lightA.transform.position, directionToLight, out hit))
        {
           
            if (hit.transform == transform)
            {
                isInLightA = true;  
            }
            else
            {
                isInLightA = false; 
            }
        }
    }

    void MoveTowardsTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        transform.position += direction * moveSpeed * Time.deltaTime;
    }
}