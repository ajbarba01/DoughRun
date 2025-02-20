using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameHandler : MonoBehaviour
{
    public TextMeshProUGUI endTitle;

    bool paused;
    // Start is called before the first frame update
    void Start()
    {
        paused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseAndPlay();
        }
    }

    public void NewWorld() {
        SceneManager.LoadScene("ArbertScene");
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

    public void MainMenu() {
        SceneManager.LoadScene("MainMenu");
    }

// THIS SHOULD ONLY DO SOMETHING WHEN IN WORLD (not menus)
    public void PauseAndPlay() {
        paused = !paused;
        if (paused) {
            Time.timeScale = 0f;
        }

        else {
            Time.timeScale = 1f;
        }
    }
}
