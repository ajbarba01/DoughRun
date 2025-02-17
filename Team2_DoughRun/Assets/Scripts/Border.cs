using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Border : MonoBehaviour
{
    // This method will be called when something collides with the border
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the object that collided is the player (using a tag or other identifier)
        if (collision.gameObject.CompareTag("Player"))
        {
            // If desired, you could add more behavior here (e.g., stop the player's movement)
            Debug.Log("Player hit the border!");
        }
    }
}
