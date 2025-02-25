using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorInteraction : MonoBehaviour
{
    public GameObject gameHandler;
    public string nextSceneName; // The name of the scene to transition to


    private void Start() {
        gameHandler = GameObject.FindWithTag("GameController");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
    Debug.Log("Triggered by: " + other.gameObject.name); // Debug log


        if (other.CompareTag("Player"))  // Make sure to tag your player
        {
            gameHandler.GetComponent<GameHandler>().LevelSelect();
        }
    }
}
