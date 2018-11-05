using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudBehaviour : MonoBehaviour {

    public GameObject[] paneles = new GameObject[5];


    void Start () {
        paneles[0].SetActive(false);
        paneles[1].SetActive(false);
        paneles[2].SetActive(false);
        paneles[3].SetActive(false);
        paneles[4].SetActive(false);
    }
	
	void Update () {
		
	}

    #region AbrirPaneles

    public void AbrirPanelSolar()
    {
        if (paneles[0].activeSelf == false)
        {
            paneles[0].SetActive(true);
            paneles[1].SetActive(false);
            paneles[2].SetActive(false);
            paneles[3].SetActive(false);
            paneles[4].SetActive(false);
        }
        else
        {
            
            paneles[0].SetActive(false);
        }
    }

    public void AbrirPanelBaterias()
    {
        if (paneles[1].activeSelf == false)
        {
            //Animacion
            paneles[0].SetActive(false);
            paneles[1].SetActive(true);
            paneles[2].SetActive(false);
            paneles[3].SetActive(false);
            paneles[4].SetActive(false);
        }
        else
        {
            paneles[1].SetActive(false);
        }
    }

    public void AbrirPanelRV()
    {
        if (paneles[2].activeSelf == false)
        {
            //Animacion
            paneles[0].SetActive(false);
            paneles[1].SetActive(false);
            paneles[2].SetActive(true);
            paneles[3].SetActive(false);
            paneles[4].SetActive(false);
        }
        else
        {
            paneles[2].SetActive(false);
        }
    }

    public void AbrirPanelInversor()
    {
        if (paneles[3].activeSelf == false)
        {
            //Animacion
            paneles[0].SetActive(false);
            paneles[1].SetActive(false);
            paneles[2].SetActive(false);
            paneles[3].SetActive(true);
            paneles[4].SetActive(false);
        }
        else
        {
            paneles[3].SetActive(false);
        }
    }

    public void AbrirPanelCables()
    {
        if (paneles[4].activeSelf == false)
        {
            //Animacion
            paneles[0].SetActive(false);
            paneles[1].SetActive(false);
            paneles[2].SetActive(false);
            paneles[3].SetActive(false);
            paneles[4].SetActive(true);
        }
        else
        {
            paneles[4].SetActive(false);
        }
    }

    #endregion
}
