using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class placeOnWorld : MonoBehaviour {

    bool positioning = true;
    GameObject GameManager;
    GameManager managingGame;
    public LineRenderer cable;

    bool goodPositioning = false;

    public Transform[] raycastPoints = new Transform[4];

    Transform myTransform;

    Color myColor;
    // Bit shift the index of the layer (8) to get a bit mask
    int layerMask = 1 << 10;

    string thisName;

    public bool solarConnected;
    public bool regulatorConnected = false;

    public bool energyFlow = false;

    private void Start()
    {
        thisName = gameObject.tag;
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
        if (!positioning)
        {
            Ray objectPos = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(objectPos, out hit, Mathf.Infinity, layerMask))
            {
                if (hit.transform.gameObject.tag == thisName)
                {
                    if (!managingGame.receiving)
                    {
                        managingGame.receivingObjectTransform = transform;
                        managingGame.receivingName = this.tag;
                        managingGame.receiving = true;
                    }
                    else if (managingGame.receiving)
                    {
                        switch (managingGame.receivingName)
                        {
                            case "Panel Solar":
                                if (thisName == "Bateria")
                                {
                                    LineRenderer cableClone = Instantiate(cable, transform.position, transform.rotation);
                                    cableClone.SetPosition(0, transform.position);
                                    cableClone.SetPosition(1, managingGame.receivingObjectTransform.position);
                                    solarConnected = true;
                                    Destroy(managingGame.receivingObjectTransform.GetComponent<placeOnWorld>());
                                }
                                break;
                            case "Bateria":
                                if (thisName == "Panel Solar" || thisName == "Regulador")
                                {
                                    LineRenderer cableClone = Instantiate(cable, transform.position, transform.rotation);
                                    cableClone.SetPosition(0, transform.position);
                                    cableClone.SetPosition(1, managingGame.receivingObjectTransform.position);
                                    if (thisName == "Panel Solar")
                                    {
                                        managingGame.receivingObjectTransform.GetComponent<placeOnWorld>().solarConnected = true;
                                        Destroy(this.GetComponent<placeOnWorld>());
                                    }
                                    if (thisName == "Regulador")
                                    {
                                        managingGame.receivingObjectTransform.GetComponent<placeOnWorld>().regulatorConnected = true;
                                    }
                                }
                                break;
                            case "Regulador":
                                if (thisName == "Bateria")
                                {
                                    LineRenderer cableClone = Instantiate(cable, transform.position, transform.rotation);
                                    cableClone.SetPosition(0, transform.position);
                                    cableClone.SetPosition(1, managingGame.receivingObjectTransform.position);
                                    regulatorConnected = true;
                                }
                                break;
                        }
                        managingGame.receiving = false;
                    }
                }
            }
        }
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
        if (Input.GetMouseButtonDown(0) && positioning && goodPositioning)
        {
            positioning = false;
            managingGame.buttonPressed = false;
            gameObject.GetComponent<Renderer>().material.color = myColor;
            gameObject.AddComponent<MeshCollider>();
            gameObject.GetComponent<MeshCollider>().convex = true;
            gameObject.AddComponent<Rigidbody>();
            gameObject.GetComponent<Rigidbody>().useGravity = false;
            gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        }
        if (solarConnected && regulatorConnected)
        {
           ExplosionDamage(myTransform.position, 10);
           solarConnected = false;
        }
    }

    void ExplosionDamage(Vector3 center, float radius)
    {
        Collider[] hitColliders = Physics.OverlapSphere(center, radius);
        int i = 0;
        while (i < hitColliders.Length)
        {
            Debug.Log(i.ToString());
            if (hitColliders[i].GetComponent<demandTest>() != null)
            {
                hitColliders[i].SendMessage("batteryDetected");
            }
            i++;
        }
    }
}
