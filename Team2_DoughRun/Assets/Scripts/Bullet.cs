using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float speed = 10f;
    private Rigidbody2D rb;

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

    void onHit() {
        // Play sfx...
        Destroy(gameObject);
    }

    IEnumerator selfDestructAfter() {
        yield return new WaitForSeconds(1);
        onHit();
    }
}
