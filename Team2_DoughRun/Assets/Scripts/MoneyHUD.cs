using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyHUD : MonoBehaviour
{
    public TextMeshProUGUI moneyText;

    // Update is called once per frame
    void Update()
    {
        moneyText.text = GameHandler.money.ToString();
    }
}
