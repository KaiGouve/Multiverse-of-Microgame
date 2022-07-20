using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Note: // If the MovementType enum does not state RB do not use Rigidbody 2D

public class MovementController2DScript : MonoBehaviour
{
    public MovementType movementType;
    public ClampMove clampMove;
    public float velocity = 1f;

    public bool flipEnable = true;

    Rigidbody2D rb;
    Animator animator;

    Vector2 direction;
    bool facingRight = true;
    bool facingDown = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        switch (movementType)
        {
            case MovementType.HORIZONTAL:
                if (flipEnable)
                {
                    transform.Translate(Mathf.Abs(direction.x) * velocity * 0.01f, 0, 0);
                    if ((direction.x > 0 && !facingRight) || (direction.x < 0 && facingRight)) { FlipH(); }
                }
                else
                {
                    if (this.transform.rotation.y == 0)
                    {
                        transform.Translate(direction.x * velocity * 0.01f, 0, 0);
                    }
                    else
                    {
                        transform.Translate(-direction.x * velocity * 0.01f, 0, 0);
                    }
                }
                break;
            case MovementType.VERTICAL:
                if (flipEnable)
                {
                    transform.Translate(0, Mathf.Abs(direction.y) * velocity * 0.01f, 0);
                    if ((direction.y < 0 && !facingDown) || (direction.y > 0 && facingDown)) { FlipV(); } // WIP
                }
                else
                {
                    transform.Translate(0, direction.y * velocity * 0.01f, 0);
                }
                break;
            case MovementType.HORIZONTAL_VERTICAL:
                if (flipEnable)
                {
                    transform.Translate(Mathf.Abs(direction.x) * velocity * 0.01f, Mathf.Abs(direction.y) * velocity * 0.01f, 0);
                    if ((direction.x > 0 && !facingRight) || (direction.x < 0 && facingRight)) { FlipH(); }
                    if ((direction.y > 0 && !facingDown) || (direction.y < 0 && facingDown)) { FlipV(); }
                }
                else
                {
                    transform.Translate(direction.x * velocity * 0.01f, direction.y * velocity * 0.01f, 0);
                }
                break;
            case MovementType.FLAPPYBIRD_RB:
                // Rigidbody 2D Body Type must be Dynamic and Collision Detection must be Discrete
                if (rb != null) { if (Input.GetMouseButtonDown(0)) { rb.velocity = Vector2.up * velocity; } }
                break;
        }
    }

    void FlipH() // Horizontal Flip
    {
        facingRight = !facingRight;
        transform.rotation = Quaternion.Euler(0, facingRight ? 0 : 180, 0);
    }

    void FlipV() // Vertical Flip
    {
        facingDown = !facingDown;
        transform.rotation = Quaternion.Euler(facingDown ? 0 : 180, 0, 0);
    }
}

[System.Serializable]
public class ClampMove
{
    [SerializeField] public bool clampEnable = false;
    [SerializeField] public Vector3 minClamp;
    [SerializeField] public Vector3 maxClamp;
}

public enum MovementType
{
    HORIZONTAL,
    VERTICAL,
    HORIZONTAL_VERTICAL,
    FLAPPYBIRD_RB,
    MARIO_RB
}
