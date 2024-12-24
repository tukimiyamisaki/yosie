using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CAMERA : MonoBehaviour
{
    public float moveSpeed = 80f;
    public float lookSpeed = 80f;
    public float clampAngle = 200f;

    private float rotationX = 0f;

    void Start()
    {
    
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        
        float mouseX = Input.GetAxis("Mouse X") * lookSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * lookSpeed;

        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -clampAngle, clampAngle);

        transform.localRotation = Quaternion.Euler(rotationX, transform.localEulerAngles.y + mouseX, 0);

       
        float moveHorizontal = Input.GetAxis("Horizontal"); 
        float moveVertical = Input.GetAxis("Vertical");

        
        Vector3 movement = transform.TransformDirection(new Vector3(moveHorizontal, 0, moveVertical));

       
        Vector3 newPosition = transform.position + movement * moveSpeed * Time.deltaTime;
        newPosition.y = transform.position.y; 
        transform.position = newPosition;
    }
}