using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryBox : MonoBehaviour
{
    public int row;
    public int col;
    public int level;
    public bool isDelivered = false;
    private bool InRange = false;

    GameObject taskHandler;
    GameObject gameHandler;

    void Start()
    {
        taskHandler = GameObject.FindWithTag("TaskHandler");
        gameHandler = GameObject.FindWithTag("GameController");

        gameHandler.GetComponent<GameHandler>().AddHouse(this);
    }
    void Update()
    {
        if (InRange == true && Input.GetKeyDown(KeyCode.E)) {
            if (this == gameHandler.GetComponent<GameHandler>().curr_delivery) {
                taskHandler.GetComponent<DeliveryTask>().newTask();
                Debug.Log("Delivered");
                isDelivered = true;
            }
            else {
                Debug.Log("Wrong house");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player"))
        {
            //Debug.Log("In Range with box");
            InRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            InRange = false;
            //Debug.Log("Out of range with box");
        }
    }


 
}
