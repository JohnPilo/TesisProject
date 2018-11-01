using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class selectPlace : MonoBehaviour {

    public bool isAvaible;
    Vector3 curNormal = Vector3.zero;
    public GameObject world;
    public GameObject cheat;
    float speed = 3;

    bool startRotating = false;

    private void OnMouseOver()
    {
        foreach (Transform building in this.transform)
        {
            if (isAvaible)
            {
                building.GetComponent<Renderer>().material.color = Color.Lerp(building.GetComponent<Renderer>().material.color, Color.green, speed * Time.deltaTime);
            }
            else
            {
                building.GetComponent<Renderer>().material.color = Color.Lerp(building.GetComponent<Renderer>().material.color, Color.red, speed * Time.deltaTime);

            }
        }
    }
    private void OnMouseExit()
    {
        StartCoroutine(changeToWhite());
    }

    IEnumerator changeToWhite()
    {
        foreach (Transform building in this.transform)
        {
            if (building.GetComponent<Renderer>().material.color != Color.white)
            {
                building.GetComponent<Renderer>().material.color = Color.Lerp(building.GetComponent<Renderer>().material.color, Color.white, speed * Time.deltaTime);
                yield return new WaitForSeconds(0.05f);
                StartCoroutine(changeToWhite());
            }
        }
    }

    private void FixedUpdate()
    {
        if (startRotating)
        {
            Quaternion toRotation = Quaternion.LookRotation(Camera.main.transform.position - cheat.transform.position);
            cheat.transform.rotation = Quaternion.Lerp(cheat.transform.rotation, toRotation, speed * Time.deltaTime);
        }
    }

    private void OnMouseDown()
    {
        if (isAvaible)
        {
            cheat.transform.LookAt(transform.position);
            world.transform.parent = cheat.transform;
            Destroy(world.GetComponent<interactWithWorld>());
            startRotating = true;
            StartCoroutine(rotate());
        }
    }

    IEnumerator rotate()
    {
        yield return new WaitForSeconds(1.4f);
        StartCoroutine(goFoward());
    }

    IEnumerator goFoward()
    {
        yield return new WaitForSeconds(0.01f);
        Camera.main.GetComponent<Rigidbody>().AddForce(transform.right);
        StartCoroutine(goFoward());
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "MainCamera")
        {
            SceneManager.LoadScene("Scene 2", LoadSceneMode.Additive);
            Camera.main.GetComponent<Rigidbody>().velocity = Vector3.zero;
            Destroy(Camera.main.GetComponent<BoxCollider>());
            Destroy(Camera.main.GetComponent<Rigidbody>());
            Destroy(this.gameObject);
        }
    }
}
