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
        transform.eulerAngles = new Vector3(0, 0, angle);
    }

    void attack() {
        attackTimer -= Time.deltaTime;
        if (attackTimer <= 0) {
            attackTimer = attackCooldown;
            if (gameHandler != null) {
                gameHandler.GetComponent<Health>().takeDamage(attackDamage);
            }
        }
    }
}
