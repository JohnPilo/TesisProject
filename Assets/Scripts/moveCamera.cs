using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCamera : MonoBehaviour {

    //The transform of this object
    Transform myTransform;
    //The amount of space before reaching the end of the screen in which the world starts rotating
    int Boundary = 20;

    //Self-explanatory
    int screenWidth;
    int screenHeight;

    //The speed in which the camera moves
    float moveSpeed = 10f;

    // Use this for initialization
    void Start () {
        //We assign the transform of this object to a holder
        myTransform = this.transform;
        //We get the screen width and height 
        screenWidth = Screen.width;
        screenHeight = Screen.height;
    }

    private void Update()
    {
        //We check the mouse position and rotate when reaching the edge boundary
        if (Input.mousePosition.x > screenWidth - Boundary)
        {
            myTransform.Translate(transform.right * Time.deltaTime * moveSpeed);
        }
        if (Input.mousePosition.x < 0 + Boundary)
        {
            myTransform.Translate(-transform.right * Time.deltaTime * moveSpeed);
        }

        if (Input.mousePosition.y > screenHeight - Boundary)
        {
            myTransform.Translate(transform.forward * Time.deltaTime * moveSpeed);
        }

        if (Input.mousePosition.y < 0 + Boundary)
        {
            myTransform.Translate(-transform.forward * Time.deltaTime * moveSpeed);
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0) 
        {
            if (myTransform.position.y > 4)
            {
                myTransform.Translate(-transform.up * Time.deltaTime * moveSpeed * 4);
            }
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0) 
        {
            myTransform.Translate(transform.up * Time.deltaTime * moveSpeed * 4);
        }
    }
}
