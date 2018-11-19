using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactWithWorld : MonoBehaviour {

    //The speed in which the world rotates when the mouse goes over the screen edge
    float rotationSpeed = 2;
    //The speed in which the world rotates when the mouse drags the world
    float rotationDrag = 300;
    //The transform of this object
    Transform myTransform;

    //The amount of space before reaching the end of the screen in which the world starts rotating
    int Boundary = 20;

    //Self-explanatory
    int screenWidth;
    int screenHeight;

    //Rigidbody of the object
    Rigidbody rigi;

    float mouseX;
    float mouseY;

    private void Start()
    {
        //We assign the rigidbody of this object to a holder
        rigi = gameObject.GetComponent<Rigidbody>();

        //We assign the transform of this object to a holder
        myTransform = this.transform;

        //We get the screen width and height 
        screenWidth = Screen.width;
        screenHeight = Screen.height;
    }

    //This happens when you click and drag the left click over the object this script is attached to
    private void OnMouseDrag()
    {
        //We get the changes in the mouse position and we translate them into degrees to affect rotation;
        mouseX = Input.GetAxis("Mouse X") * rotationDrag * Mathf.Deg2Rad;
        mouseY = Input.GetAxis("Mouse Y") * rotationDrag * Mathf.Deg2Rad;

        //We rotate the script object with the mouse input
        myTransform.Rotate(Camera.main.transform.up, -mouseX, Space.World);
        myTransform.Rotate(Camera.main.transform.right, mouseY, Space.World);
    }

    private void Update()
    {
        //We check the mouse position and rotate when reaching the edge boundary
        if (Input.mousePosition.x > screenWidth - Boundary)
        {
            myTransform.Rotate(Camera.main.transform.up, -rotationSpeed * Mathf.Rad2Deg * Time.deltaTime, Space.World);
        }
        if (Input.mousePosition.x < 0 + Boundary)
        {
            myTransform.Rotate(Camera.main.transform.up, rotationSpeed * Mathf.Rad2Deg * Time.deltaTime, Space.World);
        }

        if (Input.mousePosition.y > screenHeight - Boundary)
        {
            myTransform.Rotate(Camera.main.transform.right, -rotationSpeed * Mathf.Rad2Deg * Time.deltaTime, Space.World);
        }

        if (Input.mousePosition.y < 0 + Boundary)
        {
            myTransform.Rotate(Camera.main.transform.right, rotationSpeed * Mathf.Rad2Deg * Time.deltaTime, Space.World);
        }
    }

    /*private void FixedUpdate()
    {
        //rigi.AddTorque(transform.up * mouseX * 3);
        //rigi.AddTorque(transform.right * mouseY * 3);
    }*/
}
