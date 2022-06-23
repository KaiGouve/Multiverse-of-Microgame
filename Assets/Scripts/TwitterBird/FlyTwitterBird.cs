using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyTwitterBird : MonoBehaviour
{
    InputManager input;

    public float velocity = 1f;
    private Rigidbody2D rb;

    void Awake()
    {
        input = (InputManager)GameObject.Find("GameManager").GetComponent(typeof(InputManager));
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        if (Input.GetKeyDown(input.spaceBar))
        {
            //Jump
            rb.velocity = Vector2.up * velocity;
        }
    }
}
