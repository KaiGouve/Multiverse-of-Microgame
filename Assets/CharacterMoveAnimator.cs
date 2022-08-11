using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMoveAnimator : MonoBehaviour
{
    [SerializeField] List<Sprite> walkLeftSprites;
    [SerializeField] List<Sprite> walkRightSprites;

    // Parameters
    public float MoveX { get; set; }
    public bool IsMoving { get; set; }

    // States
    SpriteAnimator walkLeftAnim;
    SpriteAnimator walkRightAnim;

    SpriteAnimator currentAnim;

    // Refrences
    SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        walkLeftAnim = new SpriteAnimator(walkLeftSprites, spriteRenderer);
        walkRightAnim = new SpriteAnimator(walkRightSprites, spriteRenderer);

        currentAnim = walkRightAnim;
    }

    private void Update()
    {
        var prevAnim = currentAnim;

        InputMove();

        if (MoveX == 1)
        { currentAnim = walkRightAnim; }
        else if (MoveX == -1)
        { currentAnim = walkLeftAnim; }

        if (currentAnim != prevAnim)
        { currentAnim.Start(); }

        if (IsMoving)
        { currentAnim.HandleUpdate(); }
        else
        { spriteRenderer.sprite = currentAnim.Frames[0]; }
    }

    void InputMove()
    {
        if (Input.GetKey("left"))
        {
            IsMoving = true;
            MoveX = -1;
        }
        else if (Input.GetKey("right"))
        {
            IsMoving = true;
            MoveX = 1;
        }
        else
        {
            IsMoving = false;
            MoveX = 0;
        }
    }

}
