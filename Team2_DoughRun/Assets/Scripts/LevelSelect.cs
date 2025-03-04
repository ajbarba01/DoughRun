using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{
    private GameHandler gameHandler;

    public Button[] buttonArr;
    // Start is called before the first frame update
    void Start()
    {
        gameHandler = GameObject.FindWithTag("GameController").GetComponent<GameHandler>();

        for (int i = 0; i < GameHandler.level; i++) {
            buttonArr[i].interactable = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            gameHandler.BaseScene();
        }
    }
}
