using UnityEngine;
using System.Collections;

public class SlowEffect : MonoBehaviour
{
    public float slowMultiplier = 0.5f;
    public float slowDuration = 1f;

    private PlayerMovement playerMovement;
    private float originalSpeed;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        if (playerMovement == null)
        {
            Debug.LogWarning("SlowEffect: No PlayerMovement found on "
                             + gameObject.name
                             + " – slow won't work!");
        }
    }

    private void OnEnable()
    {
        if (playerMovement != null)
        {
            StartCoroutine(SlowRoutine());
        }
    }

    private IEnumerator SlowRoutine()
    {
        // Save the current speed
        originalSpeed = playerMovement.speed;
        // Apply slow
        playerMovement.speed = originalSpeed * slowMultiplier;

        // Wait for slowDuration seconds
        yield return new WaitForSeconds(slowDuration);

        // Restore original speed and remove this component
        playerMovement.speed = originalSpeed;
        Destroy(this);
    }
}
