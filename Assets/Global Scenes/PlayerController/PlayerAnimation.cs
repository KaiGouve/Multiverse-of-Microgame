using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sR;
    Animator anim;
    SurvivalPlayer ctrlr;

    bool grounded;

    private void Start()
    {
        ctrlr = GetComponent<SurvivalPlayer>();
        rb = GetComponent<Rigidbody2D>();
        sR = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }


    private void Update()
    {
        grounded = ctrlr.onGround;
        
        if (rb.velocity.x != 0) { sR.flipX = rb.velocity.x > 0 ? false : true; }

        if (grounded && Mathf.Abs(rb.velocity.x) < 0.01)
        {
            anim.SetInteger("State", 0);
        }
        else if (grounded && Mathf.Abs(rb.velocity.x) > 0.01)
        {
            anim.SetInteger("State", 1);
        }
        else if (rb.velocity.y > 0)
        {
            anim.SetInteger("State", 2);
        }
    }




}
