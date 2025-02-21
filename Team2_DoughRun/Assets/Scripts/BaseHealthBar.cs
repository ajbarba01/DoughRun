using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseHealthBar : MonoBehaviour
{

    public Image baseBar;
    public BaseHealth baseHealth;

    // Start is called before the first frame update
    void Start()
    {
    }

    void Update() {
        setBaseHealth(baseHealth.getPercentageBase());
    }

    // Update is called once per frame
    void setBaseHealth(float fraction)
    {
        baseBar.fillAmount = fraction;
    }
}
