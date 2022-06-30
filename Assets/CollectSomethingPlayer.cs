using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectSomethingPlayer : MonoBehaviour
{
    bool grounded;
    float grav = -0.01f;
    float jumpSpeed = 0.03f;
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
        transform.Translate(Input.GetAxis("Horizontal") * 0.01f, 0, 0);
        transform.Translate(0, Input.GetAxis("Jump") * jumpSpeed, 0);
        if (!grounded) {transform.Translate(0, grav, 0);}

        if (coinCount == 5) {/* Win State */}
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Obstacle"){
            grounded = true;
        }

        if (other.gameObject.tag == "Coin"){
            coinCount ++;
            Destroy(other.gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag == "Obstacle") {
            grounded = false;
        }
    }
}
