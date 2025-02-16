using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Name of the options scene
    public string optionsSceneName = "OptionsMenuScene";

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(optionsSceneName, LoadSceneMode.Additive);
            Time.timeScale = 0f;
        }
    }
}
