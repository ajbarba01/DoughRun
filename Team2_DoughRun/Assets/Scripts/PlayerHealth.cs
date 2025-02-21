using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Health
{
    public override void Die() {
        gameObject.GetComponent<GameHandler>().LoseLevel();
    }
}
