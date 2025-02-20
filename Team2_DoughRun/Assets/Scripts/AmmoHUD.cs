using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AmmoHUD : MonoBehaviour
{
    public TextMeshProUGUI ammo;
    public TextMeshProUGUI maxAmmo;

    public IcingGun gun;

    // Start is called before the first frame update
    void Start()
    {
        maxAmmo.text = gun.GetClipSize().ToString();
    }

    void Update() {
        ammo.text = gun.GetAmmo().ToString();
    }
}