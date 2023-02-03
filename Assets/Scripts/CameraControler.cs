using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour
{
public float fastSpeed = 0.3f;
public float normalSpeed = 0.15f;
public float movementSpeed = 0.15f;
public float movementTime = 1f;   
public float zoomSensitivity = 2f; 
public float fastZoomSpeed = 4f;
public float normalZoomSpeed = 2f;
public float rotationAmount;

Vector3 newPosition;
//Quaternion newRotation;




    // Start is called before the first frame update
    void Start()
    {
        newPosition = transform.position;
        //newRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        CameraMovementInput();

    if  (movementSpeed != 0f){
        movementSpeed *= 0.2f;
    }

    void CameraMovementInput() {


        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift) ) {
            movementSpeed = fastSpeed;
            
        }
        else {
            movementSpeed = normalSpeed;
           
        }



       


        //MouseWheel Camera Zoom
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            newPosition += transform.forward * zoomSensitivity ;
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            newPosition += transform.forward * -zoomSensitivity ;
        }

        //WASD Input Camera Position
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            newPosition += transform.right * movementSpeed  ;
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            newPosition += transform.right * -movementSpeed ;
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
          newPosition += transform.forward * movementSpeed ;
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
           newPosition += transform.forward * -movementSpeed ;
        }

        if (Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.PageUp))
        {   
             transform.rotation *=  Quaternion.Euler(0, 1, 0);
            
        } 
        if (Input.GetKey(KeyCode.E) || Input.GetKey(KeyCode.PageDown))
        {   
             transform.rotation *=  Quaternion.Euler(0, -1, 0);
            
        }


        // transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, Time.deltaTime * movementTime);
        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * movementTime); 

      

    }


   
     
    }
}
