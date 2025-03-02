using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : MonoBehaviour
{

    GameObject gameHandler;
    GameObject player;

    public float moveSpeed = 4f;
    private float distance;
    public float attackRange = 2f;
    public float attackCooldown = 2f;
    private float attackTimer;
    public float attackDamage = 10f;
    // Start is called before the first frame update
    void Start()
    {
        gameHandler = GameObject.FindWithTag("GameController");
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;

        if (distance > attackRange) {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
        }

        else {
            attack();
        }

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0, 0, angle - 90);
    }

    //void attack() {
    //    attackTimer -= Time.deltaTime;
    //    if (attackTimer <= 0) {
    //        attackTimer = attackCooldown;
    //        if (gameHandler != null) {
    //            gameHandler.GetComponent<Health>().takeDamage(attackDamage);
    //        }
    //    }
    //}

    void attack()
    {
        attackTimer -= Time.deltaTime;
        if (attackTimer <= 0)
        {
            attackTimer = attackCooldown;

            // First, do your usual direct damage
            if (gameHandler != null)
            {
                gameHandler.GetComponent<Health>().takeDamage(attackDamage);
            }

            // Then, if you want to poison the same object:
            // 1) Find the same GameObject that has the Health script
            //    (e.g. your "GameController" if that’s actually holding the Health)
            Health targetHealth = gameHandler.GetComponent<Health>();
            if (targetHealth != null)
            {
                // 2) Check if the PoisonEffect script is already on it
                PoisonEffect poison = targetHealth.GetComponent<PoisonEffect>();
                if (poison == null)
                {
                    // If not, add it
                    poison = targetHealth.gameObject.AddComponent<PoisonEffect>();
                }

                // OPTIONAL: If you want to override the default poison settings
                // each time you apply it, do it here:
                poison.poisonDuration = 5f;       // 5 seconds
                poison.poisonTickDamage = 2f;     // damage each tick
                poison.poisonTickInterval = 1f;   // seconds between ticks

                // If you want it to “restart” the timer each time the rat hits:
                // you could remove and re-add the script, or force a restart method.
            }
        }
    }

}
