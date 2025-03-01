using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameHandler : MonoBehaviour
{
    public BaseHealth baseHealth;
    public TextMeshProUGUI endTitle;
    public int deliveries;
    public List<List<DeliveryBox>> neighborhoods;
    public DeliveryBox curr_delivery;
    private List<DeliveryBox> n;

    public static int money;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 3; i++) {
            neighborhoods.Add(n);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void NewWorld() {
        SceneManager.LoadScene("BaseScene");
    }

    public void Quit() {
        Application.Quit();
    }
    
    public void Options() {
        // SceneManager.LoadScene("ArbertScene");
    }

    public void Win() {
        SceneManager.LoadScene("EndMenu");
        endTitle.text = "YOU WON";
    }

    public void Lose() {
        SceneManager.LoadScene("EndMenu");
        endTitle.text = "YOU LOST";
        neighborhoods.Clear();
    }
    public void WinLevel() {
        SceneManager.LoadScene("BaseScene");
        baseHealth.takeDamage(10f);
        money += 5;
    }
    public void LoseLevel() {
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
        SceneManager.LoadScene("Level" + level.ToString());
        deliveries = 5;
    }

    public void completeDelivery() {
        deliveries--;
        if (deliveries == 0) {
            WinLevel();
        }
    }

    public void AddHouse(DeliveryBox house) {
        neighborhoods[house.level].Add(house);
    }


    public bool SpendMoney(int cost)
    {
        if (money >= cost)
        {
            money -= cost;
            Debug.Log("Coins spent. Remaining: " + money);
            return true;
        }
        else
        {
            Debug.Log("Not enough coins!");
            return false;
        }
    }
}

