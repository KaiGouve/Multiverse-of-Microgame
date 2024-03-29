﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FlyTwitterBird : MonoBehaviour
{
    InputManager input;

    public float velocity = 1f;
    private Rigidbody2D rb;

    public UnityEvent detectObj;
    [SerializeField] Animator anim;
    AudioSource aS;

    void Awake()
    {
        input = (InputManager)GameObject.Find("GameManager").GetComponent(typeof(InputManager));
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        aS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(input.spaceBar))
        //if (Input.GetMouseButtonDown(0))
        {
            //Jump
            rb.velocity = Vector2.up * velocity;
            anim.SetTrigger("Flap");
            aS.Play();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        detectObj.Invoke(); // Game Over
    }
}
