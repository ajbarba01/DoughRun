using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameHandler : MonoBehaviour
{
    public BaseHealth baseHealth;
    public TextMeshProUGUI endTitle;

    // Start is called before the first frame update
    void Start()
    {
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
    }
    public void WinLevel() {
        SceneManager.LoadScene("BaseScene");
        baseHealth.takeDamage(10f);
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
    }
}
