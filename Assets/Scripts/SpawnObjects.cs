using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnObjects : MonoBehaviour {

    public GameObject[] objects;
    string thisButton;
    GameManager manageGame;
    public GameObject managerOfGames;

    private void Start()
    {
        manageGame = managerOfGames.GetComponent<GameManager>();
    }

    public void OnClicked(Button button)
    {
        thisButton = button.name;
        if (!manageGame.buttonPressed) {
            switch (thisButton)
            {
                case "Button_BateriaA":
                    spawnObject(0);
                    break;
                case "Button_PanelA":
                    spawnObject(1);
                    break;
                case "Button_ReguladorA":
                    spawnObject(2);
                    break;
            }
            manageGame.buttonPressed = true;
        }
    }

    private void spawnObject(int number)
    {
        Vector3 newPos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        newPos.z = -0.5f;
        GameObject clone = Instantiate(objects[number], newPos, Quaternion.identity);
        clone.SetActive(true);
    }
}
