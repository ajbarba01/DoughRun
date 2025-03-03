using UnityEngine;

public class PoisonChase : Chase
{
    [Header("Poison Settings")]
    public float poisonDuration = 5f; // How long poison lasts
    public float poisonTickDamage = 5f; // Damage per poison tick
    public float poisonTickInterval = 1f; // Seconds between each poison tick

    // Override the attack method from Chase
    protected override void attack()
    {
        // 1) Perform the base (normal) attack from Chase
        base.attack();

        // 2) Then add poison to the same target
        if (gameHandler != null)
        {
            // Grab the Health on the same GameObject that the rat normally damages
            Health targetHealth = gameHandler.GetComponent<Health>();
            if (targetHealth != null)
            {
                // Check if we already have a PoisonEffect on it
                PoisonEffect poison = targetHealth.GetComponent<PoisonEffect>();
                if (poison == null)
                {
                    // If not, add it
                    poison = targetHealth.gameObject.AddComponent<PoisonEffect>();
                }

                // Now override the poison settings (if desired)
                poison.poisonDuration = poisonDuration;
                poison.poisonTickDamage = poisonTickDamage;
                poison.poisonTickInterval = poisonTickInterval;
            }
        }
    }
}
