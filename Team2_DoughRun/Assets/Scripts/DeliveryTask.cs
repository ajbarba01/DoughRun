using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DeliveryTask : MonoBehaviour
{

    public TextMeshProUGUI CurrDelivery;
    public TextMeshProUGUI RemDelivery;

    public List<DeliveryBox> neighborhood;
    public int level;
    
    public GameObject deliveryProgress;
    public Image progressImage;

    GameObject gameHandler;
    DeliveryBox currD;

    // Start is called before the first frame update
    void Start()
    {
        gameHandler = GameObject.FindWithTag("GameController");
        RemDelivery.text = "Remaining Deliveries: " + GameHandler.deliveries.ToString();
        currD = gameHandler.GetComponent<GameHandler>().getCurrent_Delivery(level);

        CurrDelivery.text = "Row: " + currD.row.ToString() + " Col: " + currD.col.ToString();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void newTask() {
        gameHandler.GetComponent<GameHandler>().completeDelivery();
        currD = gameHandler.GetComponent<GameHandler>().getCurrent_Delivery(level);
        CurrDelivery.text = "Row: " + currD.row.ToString() + " Col: " + currD.col.ToString();
        RemDelivery.text = "Remaining Deliveries: " + GameHandler.deliveries.ToString();
    }

    public void SetDelivering(bool delivering) {
        deliveryProgress.SetActive(delivering);
        SetFill(0f);
    }

    public void SetFill(float fill) {
        progressImage.fillAmount = fill;
    }
}
