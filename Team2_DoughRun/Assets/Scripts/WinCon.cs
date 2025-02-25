using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCon : MonoBehaviour
{

    GameObject gameHandler;
    // Start is called before the first frame update
    void Start()
    {
        gameHandler = GameObject.FindWithTag("GameController");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            gameHandler.GetComponent<GameHandler>().WinLevel();
        }
    }
}
