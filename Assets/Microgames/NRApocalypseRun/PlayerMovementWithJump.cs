using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementWithJump : MonoBehaviour
{
    // this has jumping, movement, and the code for groundCheck. You must do
    // things yourself in the unity editor to for groundCheck. Code Tested
    // unity 2d platformer


    public float speed = 5f;
    public float jumpSpeed = 3f;
    private float direction = 0f;
    private Rigidbody2D player;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    private bool isTouchingGround;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        isTouchingGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        direction = Input.GetAxis("Horizontal");

        if (direction > 0f)
        {
            player.velocity = new Vector2(direction * speed, player.velocity.y);
        }
        else if (direction < 0f)
        {
            player.velocity = new Vector2(direction * speed, player.velocity.y);
        }
        else
        {
            player.velocity = new Vector2(0, player.velocity.y);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isTouchingGround)
        {
            player.velocity = new Vector2(player.velocity.x, jumpSpeed);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Hambaga");
        }
    }
}