using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelect : MonoBehaviour
{
    private GameHandler gameHandler;
    // Start is called before the first frame update
    void Start()
    {
        gameHandler = GameObject.FindWithTag("GameController").GetComponent<GameHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            gameHandler.BaseScene();
        }
    }
}
