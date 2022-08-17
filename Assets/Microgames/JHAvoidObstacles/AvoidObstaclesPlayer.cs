using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AvoidObstaclesPlayer : MonoBehaviour
{
    Animator anim;
    SpriteRenderer sR;
    [SerializeField] UnityEvent Fail;
    
    // Start is called before the first frame update
    void Start()
    {
        sR = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        var pos = transform.position;
        pos.x =  Mathf.Clamp(transform.position.x, -7.75f, 7.75f);
        transform.position = pos;

        transform.Translate(Input.GetAxis("Horizontal") * 0.01f, 0, 0);

        //Animation

        if (Input.GetAxis("Horizontal") != 0) { sR.flipX = Input.GetAxis("Horizontal") > 0 ? false : true; }

        if (Mathf.Abs(Input.GetAxis("Horizontal")) < 0.01)
        {
            anim.SetInteger("State", 0);
        }
        else if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0.01)
        {
            anim.SetInteger("State", 1);
        }



    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "SFX") {
            Debug.Log("You Lose");
            Fail.Invoke();
            Destroy(gameObject);
        }
    }
}


