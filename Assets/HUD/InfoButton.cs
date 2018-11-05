using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoButton : MonoBehaviour {

    public GameObject panelSolarA;

    GameObject panelMostrado;
    public Canvas HUD;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void MostrarPanel(string tipo)
    {
        panelMostrado = null;
        //instanciar tipos de paneles
        switch (tipo)
        {
            case "SolarA":
                panelMostrado = Instantiate(Resources.Load("PanelInfo_PanelA", typeof(GameObject)),
                    Input.mousePosition - new Vector3(10, 10, 0),
                    Quaternion.identity) as GameObject;
                panelMostrado.transform.SetParent(HUD.transform);
                break;
            case "SolarB":
                panelMostrado = Instantiate(Resources.Load("PanelInfo_PanelB", typeof(GameObject)),
                    Input.mousePosition - new Vector3(10, 10, 0),
                    Quaternion.identity) as GameObject;
                panelMostrado.transform.SetParent(HUD.transform);
                break;
            case "SolarC":
                panelMostrado = Instantiate(Resources.Load("PanelInfo_PanelC", typeof(GameObject)),
                    Input.mousePosition - new Vector3(10, 10, 0),
                    Quaternion.identity) as GameObject;
                panelMostrado.transform.SetParent(HUD.transform);
                break;
            case "BateriaA":
                panelMostrado = Instantiate(Resources.Load("PanelInfo_BateriaA", typeof(GameObject)),
                    Input.mousePosition - new Vector3(10, 10, 0),
                    Quaternion.identity) as GameObject;
                panelMostrado.transform.SetParent(HUD.transform);
                break;
            case "BateriaB":
                panelMostrado = Instantiate(Resources.Load("PanelInfo_BateriaB", typeof(GameObject)),
                    Input.mousePosition - new Vector3(10, 10, 0),
                    Quaternion.identity) as GameObject;
                panelMostrado.transform.SetParent(HUD.transform);
                break;
            case "BateriaC":
                panelMostrado = Instantiate(Resources.Load("PanelInfo_BateriaC", typeof(GameObject)),
                    Input.mousePosition - new Vector3(10, 10, 0),
                    Quaternion.identity) as GameObject;
                panelMostrado.transform.SetParent(HUD.transform);
                break;
            case "ReguladorA":
                panelMostrado = Instantiate(Resources.Load("PanelInfo_ReguladorA", typeof(GameObject)),
                    Input.mousePosition - new Vector3(10, 10, 0),
                    Quaternion.identity) as GameObject;
                panelMostrado.transform.SetParent(HUD.transform);
                break;
            case "ReguladorB":
                panelMostrado = Instantiate(Resources.Load("PanelInfo_ReguladorB", typeof(GameObject)),
                    Input.mousePosition - new Vector3(10, 10, 0),
                    Quaternion.identity) as GameObject;
                panelMostrado.transform.SetParent(HUD.transform);
                break;
            case "InversorA":
                panelMostrado = Instantiate(Resources.Load("PanelInfo_InversorA", typeof(GameObject)),
                    Input.mousePosition - new Vector3(10, 10, 0),
                    Quaternion.identity) as GameObject;
                panelMostrado.transform.SetParent(HUD.transform);
                break;
            case "InversorB":
                panelMostrado = Instantiate(Resources.Load("PanelInfo_InversorB", typeof(GameObject)),
                    Input.mousePosition - new Vector3(10, 10, 0),
                    Quaternion.identity) as GameObject;
                panelMostrado.transform.SetParent(HUD.transform);
                break;
            case "InversorC":
                panelMostrado = Instantiate(Resources.Load("PanelInfo_InversorC", typeof(GameObject)),
                    Input.mousePosition - new Vector3(10, 10, 0),
                    Quaternion.identity) as GameObject;
                panelMostrado.transform.SetParent(HUD.transform);
                break;
            case "InversorD":
                panelMostrado = Instantiate(Resources.Load("PanelInfo_InversorD", typeof(GameObject)),
                    Input.mousePosition - new Vector3(10, 10, 0),
                    Quaternion.identity) as GameObject;
                panelMostrado.transform.SetParent(HUD.transform);
                break;
            case "CableA":
                panelMostrado = Instantiate(Resources.Load("PanelInfo_CableA", typeof(GameObject)),
                    Input.mousePosition - new Vector3(10, 10, 0),
                    Quaternion.identity) as GameObject;
                panelMostrado.transform.SetParent(HUD.transform);
                break;
            case "CableB":
                panelMostrado = Instantiate(Resources.Load("PanelInfo_CableB", typeof(GameObject)),
                    Input.mousePosition - new Vector3(10, 10, 0),
                    Quaternion.identity) as GameObject;
                panelMostrado.transform.SetParent(HUD.transform);
                break;
        }
    }

    public void OcultarPanel ()
    {
        Destroy(panelMostrado);
    }
}
