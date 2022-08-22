using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectSomethingPlayer : MonoBehaviour
{
    bool grounded;
    float grav = -0.01f;
    float jumpSpeed = 0.03f;
    float moveSpeed = 0.01f;
    int coinCount;
    // Start is called before the first frame update
    void Start()
    {
        coinCount = 0;
        grounded = false;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(grounded);
        Debug.Log(jumpSpeed);
        transform.Translate(Input.GetAxis("Horizontal") * moveSpeed, 0, 0);
        transform.Translate(0, Input.GetAxis("Jump") * jumpSpeed, 0);
        if (Input.GetKeyUp("space")) {jumpSpeed = 0;}
        if (!grounded) {
            transform.Translate(0, grav, 0);
            jumpSpeed -= jumpSpeed / 500;
            }

        if (coinCount == 5) {/* Win State */}
    }

    void OnTriggerEnter2D(Collider2D other) {

        // Get position of collision relatve to player;
        Vector3 toTarget = (other.gameObject.transform.position - transform.position).normalized;

        if (other.gameObject.tag == "Obstacle") {
            if(Vector3.Dot(toTarget, -gameObject.transform.up) > 0) {
                grounded = true;
                jumpSpeed = 0.03f;
            }

            else if(Vector3.Dot(toTarget, gameObject.transform.up) > 0) {
                jumpSpeed = 0.00f;
            }
        }

        if (other.gameObject.tag == "Coin") {
            Destroy(other.gameObject);
            coinCount ++;
        }

        

        
    }

    void OnTriggerExit2D(Collider2D other) {
        Vector3 toTarget = (other.gameObject.transform.position - transform.position).normalized;
        jumpSpeed = 0.03f;
        moveSpeed = 0.01f;
        if (other.gameObject.tag == "Obstacle") {
            if(Vector3.Dot(toTarget, -gameObject.transform.up) > 0) {
                grounded = false;
                
            }
        }
    }

}
