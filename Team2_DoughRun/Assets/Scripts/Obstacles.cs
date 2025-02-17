using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    public float damage = 10;

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collision detected with: " + other.gameObject.name);
        
        // Example: Check if the colliding object has a specific tag
        if (other.gameObject.CompareTag("Player"))
        {
            Health playerHealth = other.GetComponent<Health>();
            if (playerHealth != null)
            {
                playerHealth.takeDamage(damage);  // Reduce health
                Debug.Log("Player hit the obstacle!");
            }
        }
    }
}
