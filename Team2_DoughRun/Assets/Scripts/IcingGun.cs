using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcingGun : MonoBehaviour
{

    public GameObject projectile;
    public Transform gunTip;
    private float gunCooldown = 0.2f;
    private float shootTimer = 0.2f;
    private float bulletSpeed = 50f;

    private Vector3 aimDirection;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleAiming();
        HandleShooting();
    }

    private void HandleAiming() {
    Vector3 mousePosition = Input.mousePosition;
    Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

    // Calculate direction from gunTip to cursor
    aimDirection = (worldPosition - transform.position).normalized;
    float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;

    transform.eulerAngles = new Vector3(0, 0, angle);
    }

    private void HandleShooting() {

        shootTimer -= Time.deltaTime;
        if (shootTimer <= 0 && Input.GetMouseButton(0)) {
            Fire();
            shootTimer = gunCooldown;
        }
    }

    private void Fire() {
        GameObject bullet = Instantiate(projectile, gunTip.position, transform.rotation);
        bullet.GetComponent<Bullet>().setSpeedDirection(bulletSpeed, transform.right);
    }
}
