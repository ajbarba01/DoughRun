using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcingGun : MonoBehaviour
{

    public GameObject projectile;
    public Transform gunTip;
    private float gunCooldown = 0.05f;
    private float shootTimer = 0f;
    private float bulletSpeed = 25f;

    private int clipSize = 25;
    private int ammo;

    private float reloadTime = 2f;

    private Vector3 aimDirection;
    // Start is called before the first frame update
    void Start()
    {
        ammo = clipSize;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) {
            Reload();
        }
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
            if (ammo > 0) {
                Fire();
                shootTimer = gunCooldown;
                ammo--;
            }
            else {
                Reload();
            }
        }
    }

    private void Fire() {

        GameObject bullet = Instantiate(projectile, gunTip.position, transform.rotation);
        bullet.GetComponent<Bullet>().setSpeedDirection(bulletSpeed, transform.right);
    }

    public void Reload() {
        ammo = clipSize;
        shootTimer = reloadTime;
    }

    public int GetClipSize() {
        return clipSize;
    }

    public int GetAmmo() {
        return ammo;
    }
}
