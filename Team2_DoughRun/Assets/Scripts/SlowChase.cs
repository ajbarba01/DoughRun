using UnityEngine;

public class SlowChase : Chase
{
    [Header("Slow Settings")]
    public float slowMultiplier = 0.5f; // Half the normal speed
    public float slowDuration = 1f; // Seconds to remain slowed

    protected override void attack()
    {
        // Perform the normal base attack from Chase
        base.attack();

        // Then apply the slow effect to the *player* object
        if (player != null)
        {
            // The player presumably has PlayerMovement
            SlowEffect slowEffect = player.GetComponent<SlowEffect>();
            if (slowEffect == null)
            {
                // Add the SlowEffect script if it doesn’t exist
                slowEffect = player.AddComponent<SlowEffect>();
            }

            // Optionally override default slow settings
            slowEffect.slowMultiplier = slowMultiplier;
            slowEffect.slowDuration = slowDuration;
        }
    }
}
