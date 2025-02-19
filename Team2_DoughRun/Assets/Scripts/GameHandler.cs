using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    public int playerHealthMax = 100;
    public static float playerHealth = 0;
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = playerHealthMax;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
