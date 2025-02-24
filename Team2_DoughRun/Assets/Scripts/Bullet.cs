using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float speed = 10f;
    private float damage = 10f;
    private Rigidbody2D rb;
    public float destroyAfter = 0.5f;

    public GameObject hitFX;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;

        Vector3 direction = (mousePosition - transform.position).normalized;

        setSpeedDirection(speed, direction);

        StartCoroutine(selfDestructAfter());
    }

    public void setSpeedDirection(float newSpeed, Vector3 direction)
    {
        speed = newSpeed;
        rb.velocity = direction * speed;
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Enemy")) {
            other.gameObject.GetComponent<Health>().takeDamage(damage);
            onHit();
        }
    }

    void onHit() {
        Destroy(Instantiate(hitFX, transform.position, Quaternion.identity), 1f);
        // Play sfx...
        Destroy(gameObject);
    }

    IEnumerator selfDestructAfter() {
        yield return new WaitForSeconds(destroyAfter);
        onHit();
    }
}
