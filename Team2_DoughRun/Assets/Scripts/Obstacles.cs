using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class DamageSlow : MonoBehaviour {

       public int damage = 1;
       public float damageTime = 0.5f;
       private bool isDamaging = false;
       private float damageTimer = 0f;
       private GameHandler gameHandlerObj;

       void Start () {
         if (GameObject.FindWithTag ("GameController") != null) {
            gameHandlerObj = GameObject.FindWithTag ("GameController").GetComponent<GameHandler>();
         }
       }

       void FixedUpdate(){
              if (isDamaging == true){
                     damageTimer += 0.1f;
                     if (damageTimer >= damageTime){
                            gameHandlerObj.GetComponent<Health>().takeDamage(damage);
                            damageTimer = 0f;
                     }
              }
       }

       void OnTriggerStay2D(Collider2D other){
              if (other.gameObject.tag == "Player") {
                     isDamaging = true;
                     Debug.Log("Contact with fire");
              }
       }

       void OnTriggerExit2D(Collider2D other){
              if (other.gameObject.tag == "Player") {
                     isDamaging = false;
              }
       }
}