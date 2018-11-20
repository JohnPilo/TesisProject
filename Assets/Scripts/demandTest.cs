using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class demandTest : MonoBehaviour {

    public float totalDemand;
    public float currentDemand;

	// Use this for initialization
	void Start () {
        totalDemand = Random.Range(600, 1000);
        currentDemand = totalDemand;
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Panel Solar")
        {
            currentDemand -= 200;
        }
    }
    /*
    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "Panel Solar")
        {
            currentDemand -= 200;
        }
    }*/

}
