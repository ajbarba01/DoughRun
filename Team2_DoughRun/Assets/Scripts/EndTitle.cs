using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndTitle : MonoBehaviour
{
    public TextMeshProUGUI endTitle;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("UHHH");
        if (GameHandler.won) {
            endTitle.text = "YOU WON!";
        }
        
        else {
            endTitle.text = "YOU LOST :(";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
