using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BaseHealth : MonoBehaviour
{
    public float currentHealth = 100f;

    public float MaxBaseHealth = 100f;
    // Start is called before the first frame update
    void Start()
    {
        // currentHealth = MaxBaseHealth;
    }

    public void takeDamage(float damage)
    {
        currentHealth -= damage;
        if(currentHealth <= 0)
        {
            SceneManager.LoadScene("EndMenu");
        }
    }
    // Update is called once per frame
    public void healHealth(float heal)
    {
        currentHealth += heal;
        if(currentHealth >= MaxBaseHealth)
        {
            currentHealth = MaxBaseHealth;
        }
    }
    public float getPercentageBase()
    {
        return currentHealth / MaxBaseHealth;
    }
}
