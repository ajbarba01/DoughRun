using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameHandler : MonoBehaviour
{
    public BaseHealth baseHealth;

    public ShopUIManager shopUIManager;

    public static int deliveries;
    public static int money;
    public static int level = 1;

    private static int currentLevel;
    public static bool won;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // COMMENT BEFORE BUILD
        if (Input.GetKeyDown(KeyCode.L)) {
            WinLevel();
        }
    }

    public void NewGame() {
        level = 1;
        currentLevel = 0;
        won = false;
        money = 0;
        deliveries = 0;
        BaseHealth.currentHealth = 100;

        BaseScene();
    }

    public void BaseScene() {
        // baseHealth.healHealth(100);
        SceneManager.LoadScene("BaseScene");
    }

    public void Quit() {
        Application.Quit();
    }
    
    public void Controls() {
        SceneManager.LoadScene("Controls");
    }

    public void Win() {
        won = true;
        SceneManager.LoadScene("EndMenu");
    }

    public void Lose() {
        won = false;
        SceneManager.LoadScene("EndMenu");
    }
    public void WinLevel() {
        if (currentLevel == 4) {
            Win();
            return;
        }

        else if (currentLevel == level) {
            level++;
        }

        SceneManager.LoadScene("BaseScene");
        baseHealth.takeDamage(10f);
        money += 5;
    }
    public void LoseLevel() {
        currentLevel = 0;
        SceneManager.LoadScene("BaseScene");
        baseHealth.takeDamage(20f);
    }

    public void MainMenu() {
        SceneManager.LoadScene("MainMenu");
    }
    
    public void LevelSelect() {
        SceneManager.LoadScene("LevelSelect");
    }

    public void SelectLevel(int level) {
        currentLevel = level;
        SceneManager.LoadScene("Level" + level.ToString());
        deliveries = 5;
    }

    public void completeDelivery() {
        deliveries--;
        if (deliveries <= 0) {
            WinLevel();
        }
    }

    public bool SpendMoney(int cost)
    {
        if (money >= cost)
        {
            money -= cost;
            shopUIManager.ShowMessage("Coins spent. Remaining: " + money);
            return true;
        }
        else
        {
            shopUIManager.ShowMessage("Not enough coins!");
            return false;
        }
    }
}

