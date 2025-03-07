using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ShopUIManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject shopUI;

    public GameHandler gameHandler;

    private PlayerMovement playerMovement;
    public BaseHealth baseHealth;

    private IcingGun icingGun;

    public TextMeshProUGUI messageText;

    public void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerMovement = player.GetComponent<PlayerMovement>();
        }
    }
    
    public void CloseShop()
    {
        shopUI.SetActive(false);
        Pause.Unfreeze();
        Pause.Unlock();
        
    }

    public void OpenShop()
    {
        shopUI.SetActive(true);
        Pause.Freeze();
        Pause.Lock();
    }

    public void UpgradeBaseHealth()
    {
        if(gameHandler.SpendMoney(10))
        {
            baseHealth.healHealth(10);
        }
    }

    public void UpgradeMoveSpeed()
    {
        if (gameHandler.SpendMoney(10))
        {
            playerMovement.increaseSpeed(5);
        }
    }
    public void UpgradeAttackSpeed()
    {
        if(gameHandler.SpendMoney(10))
        {
            icingGun.upAttackSpeed();
        }
    }
    public void ShowMessage(string Message)
    {
        messageText.text = Message;
        CancelInvoke(nameof(ClearMessage));
        Invoke(nameof(ClearMessage), 2f);
    }
    private void ClearMessage()
    {
        messageText.text = "";
    }
}
