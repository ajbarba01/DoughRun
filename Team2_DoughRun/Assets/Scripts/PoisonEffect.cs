using UnityEngine;
using System.Collections;

public class PoisonEffect : MonoBehaviour
{
    [Header("Poison Settings")]
    [Tooltip("How long (in seconds) the poison lasts.")]
    public float poisonDuration = 5f;

    [Tooltip("Damage dealt each time the poison ticks.")]
    public float poisonTickDamage = 5f;

    [Tooltip("Seconds between each poison tick.")]
    public float poisonTickInterval = 1f;

    // Reference to your existing Health component
    private Health healthComponent;

    private void Awake()
    {
        // Get the Health component on *this* GameObject
        healthComponent = GetComponent<Health>();
        if (healthComponent == null)
        {
            Debug.LogWarning("PoisonEffect: No 'Health' component found on " 
                             + gameObject.name 
                             + " – poison will not work!");
        }
    }

    private void OnEnable()
    {
        // Start the poison as soon as this component is enabled
        if (healthComponent != null)
        {
            StartCoroutine(ApplyPoisonOverTime());
        }
    }

    private IEnumerator ApplyPoisonOverTime()
    {
        float elapsed = 0f;

        while (elapsed < poisonDuration)
        {
            // Deal damage
            healthComponent.takeDamage(poisonTickDamage);

            // Wait for the tick interval
            yield return new WaitForSeconds(poisonTickInterval);

            // Increase elapsed time
            elapsed += poisonTickInterval;
        }

        // Optional: Remove this component after the poison duration is up
        Destroy(this);
    }
}
