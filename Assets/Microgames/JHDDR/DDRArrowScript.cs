using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DDRArrowScript : MonoBehaviour
{
    float rotX;
    float rotY;
    int type;
    bool ready;

    KeyCode[] direction =
    {
        KeyCode.UpArrow,KeyCode.LeftArrow,KeyCode.RightArrow,KeyCode.DownArrow,KeyCode.W,KeyCode.A,KeyCode.D,KeyCode.S
    };
    public DDRController DDRC;

    // Start is called before the first frame update
    void Start()
    {
        switch(transform.position.y) {
            // Up Arrows
            case 3.5f:
                this.GetComponent<SpriteRenderer>().color = Color.red;
                type = 0;
                break;
            // Left Arrows
            case 1.2f:
                this.GetComponent<SpriteRenderer>().color = Color.blue;
                type = 1;
                break;
            // Right Arrows
            case -1.2f:
                this.GetComponent<SpriteRenderer>().color = Color.green;
                type = 2;
                break;
            // Down Arrows
            case -3.5f:
                this.GetComponent<SpriteRenderer>().color = Color.yellow;
                type = 3;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (ready)
        {
            if (Input.GetKeyDown(direction[type]) || Input.GetKeyDown(direction[type + 4]))
            {
                DDRC.successful++;
                type = 4;
                this.GetComponent<SpriteRenderer>().color = Color.black;
                ready = false;

            }
        }

        if (transform.position.x < -9 && type<4)
        {
            //fail
            Debug.LogError($"FAILED");
            type = 5;
        }





    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (type >= 0)
        {
            ready = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        ready = false;
    }
}
