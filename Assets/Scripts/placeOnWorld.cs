using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class placeOnWorld : MonoBehaviour {

    bool positioning = true;
    GameObject GameManager;
    GameManager managingGame;
    public LineRenderer cable;

    bool panelCheck = false;
    bool bateriaCheck = false;

    bool goodPositioning = false;

    public Transform[] raycastPoints = new Transform[4];

    Transform myTransform;

    Color myColor;
    // Bit shift the index of the layer (8) to get a bit mask
    int layerMask = 1 << 9;


    private void Start()
    {
        // This would cast rays only against colliders in layer 8.
        // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
        layerMask = ~layerMask;
        GameManager = GameObject.FindGameObjectWithTag("GameManager");
        managingGame = GameManager.GetComponent<GameManager>();
        myTransform = gameObject.transform;
        myColor = gameObject.GetComponent<Renderer>().material.color;
        int i = 0;
        foreach(Transform child in myTransform){
            raycastPoints[i] = child;
            i++;
        }
    }

    private void Update()
    {
        if (positioning)
        {
            Ray objectPos = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(objectPos, out hit, Mathf.Infinity, layerMask))
            {
                transform.position = hit.point;
                transform.rotation = Quaternion.LookRotation(hit.normal);
                for (int i = 0; i < raycastPoints.Length; i++)
                {
                    RaycastHit hit2;
                    
                    if (Physics.Raycast(raycastPoints[i].position, -transform.forward, out hit2, 0.5f, layerMask))
                    {
                            goodPositioning = true;
                        gameObject.GetComponent<Renderer>().material.color = Color.green;
                        Debug.Log("why do i exist");
                    }
                    else
                    {
                        goodPositioning = false;
                        gameObject.GetComponent<Renderer>().material.color = Color.red;
                        break;
                    }
                }
            }
            
        }
        if (Input.GetMouseButtonDown(0) &&  positioning && goodPositioning)
        {
            positioning = false;
            managingGame.buttonPressed = false;
            gameObject.GetComponent<Renderer>().material.color = myColor;
            gameObject.AddComponent<MeshCollider>();
            gameObject.GetComponent<MeshCollider>().convex = true;
            gameObject.AddComponent<Rigidbody>();
            gameObject.GetComponent<Rigidbody>().useGravity = false;
        }
        if(panelCheck && bateriaCheck)
        {
            managingGame.energyLevel += 10;
            panelCheck = false;
            bateriaCheck = false;
        }
    }

    private void OnMouseDown()
    {
        if (!positioning)
        {
            if (!managingGame.receiving)
            {
                managingGame.receivingObjectPosition = transform.position;
                managingGame.receivingName = this.name;
                managingGame.receiving = true;
            }
            else if (managingGame.receiving)
            {
                LineRenderer cableClone = Instantiate(cable, transform.position, transform.rotation);
                cableClone.SetPosition(0, transform.position);
                cableClone.SetPosition(1, managingGame.receivingObjectPosition);

                managingGame.receiving = false;
            }
        }

    }
    /*
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        for (int i = 0; i <= raycastPoints.Length; i++)
        {
            Ray anchorPoint = new Ray(raycastPoints[i].position, -transform.up);
            RaycastHit hit1;
            if (goodPositioning)
            {
                Gizmos.color = Color.green;
            }
            else
            {
                Gizmos.color = Color.red;
            }
        }
    }*/

}
