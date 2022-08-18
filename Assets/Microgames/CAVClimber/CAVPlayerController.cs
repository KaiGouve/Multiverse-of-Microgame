using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CAVPlayerController : MonoBehaviour
{
    float Horiz;
    Vector2 vel;
    Rigidbody2D rb;
    bool grounded;
    public UnityEvent nextScene;
    [SerializeField] Animator anim;
    bool ladder=false;
    SpriteRenderer sR;
    [SerializeField] AudioSource aS;

    // Start is called before the first frame update
    void Start()
    {
        sR = GetComponent<SpriteRenderer>();
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
        if(grounded&& Input.GetKey(KeyCode.Space)|| grounded && Input.GetKey(KeyCode.W))
        {
            vel.y = 7.2f;
            if (!ladder)
            {
                aS.Play();
            }
            
        }

        rb.gravityScale = grounded&&vel.y<=0 ? 0 : 1;

        vel.x = Horiz*7;


        rb.velocity = vel;

        if (transform.position.y > 25)
        {
            //WIN
            nextScene.Invoke();
            transform.position -= new Vector3(15,5);
        }

        if (vel.x != 0){sR.flipX = vel.x > 0 ? false : true;}

        if( grounded && Mathf.Abs(vel.x) < 0.01 &&!ladder)
        {
            anim.SetInteger("State", 0);
        }else if (grounded && Mathf.Abs(vel.x)>0.01&&!ladder)
        {
            anim.SetInteger("State", 1);
        }
        else if (vel.y > 0)
        {
            if (grounded && ladder)
            {
                anim.SetInteger("State", 3);
            }
            else
            {
                anim.SetInteger("State", 2);
            }
        }

    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Ground"&&!grounded)
        {
            grounded = true;
            if (other.name == "Ladder")
            {
                ladder = true;
            }
            else
            {
                ladder = false;
            }

        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Ground"&&grounded)
        {
            grounded = false;
            ladder = false;

        }
    }

}
