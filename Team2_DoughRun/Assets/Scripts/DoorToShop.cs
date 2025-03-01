using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DoorToShop : MonoBehaviour
{
    public GameObject gameHandler;
    public string nextSceneName; 


    private void Start() {
        gameHandler = GameObject.FindWithTag("GameController");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
    Debug.Log("Triggered by: " + other.gameObject.name); 


        if (other.CompareTag("Player")) 
        {
            SceneManager.LoadScene("Shop");
        }
    }
}
