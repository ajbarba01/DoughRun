using UnityEngine;

public class DoorInteraction : MonoBehaviour
{
    public string nextSceneName; // The name of the scene to transition to

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))  // Make sure to tag your player
        {
            // You can load the next scene or perform other actions
            UnityEngine.SceneManagement.SceneManager.LoadScene(nextSceneName);
        }
    }
}
