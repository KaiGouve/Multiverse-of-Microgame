using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CAVPlayerController : MonoBehaviour
{
    float Horiz;
    Vector2 vel;
    Rigidbody2D rb;
    bool grounded;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Horiz = Mathf.Lerp(Horiz, Input.GetAxis("Horizontal"),Time.deltaTime*10);

        

        vel = rb.velocity;
        if (vel.y < 0 && grounded)
        {
            vel.y = 0;
        }
        if(grounded&& Input.GetKey(KeyCode.Space))
        {
            vel.y = 6;
        }

        rb.gravityScale = grounded&&vel.y<=0 ? 0 : 1;

        vel.x = Horiz*7;


        rb.velocity = vel;

        if (transform.position.y > 25)
        {
            //WIN
            Debug.Log("WIN");
        }



    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Ground"&&!grounded)
        {
            Debug.Log("grounded");
            grounded = true;

        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Ground"&&grounded)
        {
            Debug.Log("ungrounded");
            grounded = false;

        }
    }

}
