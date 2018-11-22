using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class demandController : MonoBehaviour {


    public GameObject barPercentage;
    public demandTest demandGet;
    public float demandPercentage;
    public Vector3 changeBar;

    private void Start()
    {
        demandPercentage = demandGet.totalDemand * 100 / demandGet.currentDemand;
        changeBar = new Vector3(3.5f - (100 * 3.5f / demandPercentage), barPercentage.transform.localScale.y, barPercentage.transform.localScale.z);
    }

    // Update is called once per frame
    void Update () {
        if(changeBar.x < 3.5f)
        {
            demandPercentage = demandGet.totalDemand * 100 / demandGet.currentDemand;
            changeBar = new Vector3(3.5f - (100 * 3.5f / demandPercentage), barPercentage.transform.localScale.y, barPercentage.transform.localScale.z);
            barPercentage.transform.localScale = changeBar;
        }
        else
        {
            changeBar.x = 3.5f;
            barPercentage.transform.localScale = changeBar;
        }
	}
}
