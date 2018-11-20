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

    public Vector3 asdjkfdsajl;

    public bool goodPositioning = false;

    public Transform[] raycastPoints = new Transform[4];

    Transform myTransform;

    private void Start()
    {
        GameManager = GameObject.FindGameObjectWithTag("GameManager");
        managingGame = GameManager.GetComponent<GameManager>();
        myTransform = gameObject.transform;
        int i = 0;
        foreach(Transform child in myTransform){
            raycastPoints[i] = child;
            i++;
        }
    }

    private void Update()
    {
        asdjkfdsajl = raycastPoints[1].position;
        if (positioning)
        {
            Ray objectPos = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(objectPos, out hit, Mathf.Infinity))
            {
                transform.position = hit.point;
                transform.rotation = Quaternion.LookRotation(hit.normal);
                for (int i = 0; i < raycastPoints.Length; i++)
                {
                    RaycastHit hit2;
                    if (Physics.Raycast(raycastPoints[i].position, -transform.forward, out hit2, 0.5f))
                    {
                            goodPositioning = true;
                        Debug.Log("why do i exist");
                    }
                    else
                    {
                        goodPositioning = false;
                        break;
                    }
                }
            }
            
        }
        if (Input.GetMouseButtonDown(0) && goodPositioning)
        {
            positioning = false;
            managingGame.buttonPressed = false;
            gameObject.AddComponent<MeshCollider>();
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
