using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatSpawn : MonoBehaviour
{

    public GameObject RatEnemy;
    public Transform drainLocation;
    private bool canSpawn = true;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerStay2D(Collider2D other) {
        if (other.CompareTag("Player"))
        {
            if (canSpawn) {
                Debug.Log("Spawning rat");
                Instantiate(RatEnemy, drainLocation);
                StartCoroutine(SpawnCooldown());
            }
        }
    }

    private IEnumerator SpawnCooldown()
    {
        canSpawn = false;
        yield return new WaitForSeconds(15f);
        canSpawn = true;
    }
}
