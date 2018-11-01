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

    private void Start()
    {
        GameManager = GameObject.FindGameObjectWithTag("GameManager");
        managingGame = GameManager.GetComponent<GameManager>();
    }

    private void Update()
    {
        if (positioning)
        {
            Ray objectPos = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(objectPos, out hit, Mathf.Infinity))
            {
                transform.position = hit.point;
                transform.rotation = Quaternion.LookRotation(hit.normal);
            }
        }
        if (Input.GetMouseButtonDown(0) && positioning)
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

}
