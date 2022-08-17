using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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
    [SerializeField] UnityEvent nextScene;
    [SerializeField] Animator anim;
    SpriteRenderer sR;
    // Start is called before the first frame update
    void Start()
    {
        sR = GetComponent<SpriteRenderer>();
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
            GetComponentInChildren<PlayerSFX>().PlaySFX(false, 2);
        }
        if (transform.position.x > 70)
        {
            nextScene.Invoke();
        }

        //Animation

        if(player.velocity.x != 0) { sR.flipX = player.velocity.x > 0 ? false : true; }

        if (isTouchingGround && Mathf.Abs(player.velocity.x) < 0.01)
        {
            anim.SetInteger("State", 0);
        }
        else if (isTouchingGround && Mathf.Abs(player.velocity.x) > 0.01)
        {
            anim.SetInteger("State", 1);
        }
        else if (player.velocity.y > 0)
        {
            {
                anim.SetInteger("State", 2);
            }
        }








    }







}