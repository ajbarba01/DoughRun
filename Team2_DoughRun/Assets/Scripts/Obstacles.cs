using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision detected with: " + collision.gameObject.name);
        
        // Example: Check if the colliding object has a specific tag
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player hit the obstacle!");
        }
    }
}
