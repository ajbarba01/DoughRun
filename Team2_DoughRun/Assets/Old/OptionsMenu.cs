using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsMenuManager : MonoBehaviour
{
    // Name of the gameplay scene (the scene where the game is being played)
    public string gameSceneName = "ArbertScene";

    // This method will be called when the Resume button is pressed
    public void ResumeGame()
    {
        // Unload the options scene
        SceneManager.UnloadSceneAsync("Menu");

        // Resume the game (set time scale back to normal)
        Time.timeScale = 1f;
    }

    
}
