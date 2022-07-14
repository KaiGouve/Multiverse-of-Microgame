using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvoidObstaclesPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        var pos = transform.position;
        pos.x =  Mathf.Clamp(transform.position.x, -7.75f, 7.75f);
        transform.position = pos;

        transform.Translate(Input.GetAxis("Horizontal") * 0.01f, 0, 0);
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Finish") {
            Debug.Log("You Lose");
            // Enter fail state
        }
    }
}


