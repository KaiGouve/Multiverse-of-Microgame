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
    [SerializeField] bool hasRb = true;
    [SerializeField] bool isBowl;

    Vector3 vel;

    private void Start()
    {
        ctrlr = GetComponent<SurvivalPlayer>();
        sR = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        if (isBowl)
        {
            anim.SetTrigger("HasBowl");
        }
        if (hasRb)
        {
            rb = GetComponent<Rigidbody2D>();

        }
    }


    private void Update()
    {
        if (ctrlr != null)
        {
            grounded = ctrlr.onGround;
        }
        else
        {
            grounded = true;
        }

        vel = hasRb ? rb.velocity:new Vector3(Input.GetAxis("Horizontal"),0,0);


        if (vel.x != 0) { sR.flipX = vel.x > 0 ? false : true; }

        if (grounded && Mathf.Abs(vel.x) < 0.1)
        {
            anim.SetInteger("State", 0);
        }
        else if (grounded && Mathf.Abs(vel.x) > 0.1)
        {
            anim.SetInteger("State", 1);
        }
        else if (vel.y > 0)
        {
            anim.SetInteger("State", 2);
        }
    }




}
