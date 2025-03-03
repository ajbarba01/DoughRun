using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryBox : MonoBehaviour
{
    public int row;
    public int col;
    public int level;
    public bool isDelivered = false;
    private bool inRange = false;
    private bool isHouse = false;

    private float deliveryTime = 3f;
    private float deliveryTimeCurr = 3f;

    DeliveryTask taskHandler;
    GameHandler gameHandler;

    void Start()
    {
        taskHandler = GameObject.FindWithTag("TaskHandler").GetComponent<DeliveryTask>();
        gameHandler = GameObject.FindWithTag("GameController").GetComponent<GameHandler>();

        gameHandler.GetComponent<GameHandler>().AddHouse(this);
    }
    void Update()
    {
        if (inRange && isHouse) {
            deliveryTimeCurr -= Time.deltaTime;
            taskHandler.SetFill((deliveryTime - deliveryTimeCurr) / deliveryTime);
            if (deliveryTimeCurr <= 0) {
                taskHandler.newTask();
                Debug.Log("Delivered");
                isDelivered = true;
                isHouse = false;
                deliveryTimeCurr = deliveryTime;
                taskHandler.SetDelivering(false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player"))
        {
            //Debug.Log("In Range with box");
            inRange = true;
            isHouse = (this == gameHandler.curr_delivery);
            if (isHouse) {
                taskHandler.SetDelivering(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            inRange = false;
            deliveryTimeCurr = deliveryTime;
            
            if (isHouse) {
                taskHandler.SetDelivering(false);
                isHouse = false;
            }
            //Debug.Log("Out of range with box");
        }
    }


 
}
