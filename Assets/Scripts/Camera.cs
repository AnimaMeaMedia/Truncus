using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public float zoomSensitivity = 2f;
    public float fastZoomSpeed = 4f;
    public float normalZoomSpeed = 2f;
    public float movementTime = 1f;
    
    private Vector3 offset;
    Vector3 newPosition;
    CameraControler parentObject;  
    void Start()
    {
        parentObject = transform.parent.GetComponent<CameraControler>();
        offset = transform.position - parentObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        CameraZoom();
        //parentObject.transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed);
        transform.position = parentObject.transform.position + offset;
       
    }
        


    void CameraZoom(){

    	if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift) ) {
            
            zoomSensitivity = fastZoomSpeed;
        }
        else {
           
            zoomSensitivity = normalZoomSpeed;
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            newPosition += transform.forward * zoomSensitivity ;
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            newPosition += transform.forward * -zoomSensitivity ;
        }
        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * movementTime); 
    }


}
