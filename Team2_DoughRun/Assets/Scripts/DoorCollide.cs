using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorInteraction : MonoBehaviour
{
    public string nextSceneName; // The name of the scene to transition to

    void OnTriggerEnter2D(Collider2D other)
    {
    Debug.Log("Triggered by: " + other.gameObject.name); // Debug log


        if (other.CompareTag("Player"))  // Make sure to tag your player
        {
            Debug.Log("JHERE");
            // You can load the next scene or perform other actions
            UnityEngine.SceneManagement.SceneManager.LoadScene(nextSceneName);
        }
    }
}
