using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteAnimExample : MonoBehaviour
{
    [SerializeField] List<Sprite> sprites;

    SpriteAnimator spriteAnimator;

    private void Start()
    {
        spriteAnimator = new SpriteAnimator(sprites, GetComponent<SpriteRenderer>());
        spriteAnimator.Start();
    }

    private void Update()
    {
        spriteAnimator.HandleUpdate();
    }
}
