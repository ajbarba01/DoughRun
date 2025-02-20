using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float health = 100;
    public float maxHealth = 100;

    public void takeDamage(float damage) {
        health -= damage;
        if (health <= 0) {
            health = 0;
            Destroy(gameObject);
        }
    }

    public void heal(float heal) {
        health += heal;
        if (health > maxHealth) {
            health = maxHealth;
        }
    }

    public float getPercentage() {
        return health / maxHealth;
    }
}
