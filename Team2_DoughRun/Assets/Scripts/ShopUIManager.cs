using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopUIManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject shopUI;

    public GameHandler gameHandler;

    public BaseHealth baseHealth;

    public void CloseShop()
    {
        shopUI.SetActive(false);
    }
    public void UpgradeBaseHealth()
    {
        if(gameHandler.SpendMoney(10))
        {
            baseHealth.healHealth(10);
        }
    }
}
