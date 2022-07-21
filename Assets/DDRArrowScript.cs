using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DDRArrowScript : MonoBehaviour
{
    float rotX;
    float rotY;
    // Start is called before the first frame update
    void Start()
    {
        switch(transform.position.y) {
            // Up Arrows
            case 3.5f:
            this.GetComponent<SpriteRenderer>().color = Color.red;
            break;
            // Left Arrows
            case 1.2f:
            this.GetComponent<SpriteRenderer>().color = Color.blue;
            break;
            // Down Arrows
            case -1.2f:
            this.GetComponent<SpriteRenderer>().color = Color.green;
            break;
            // Right Arrows
            case -3.5f:
            this.GetComponent<SpriteRenderer>().color = Color.yellow;
            break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
