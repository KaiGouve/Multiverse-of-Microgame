using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CAVFlip : MonoBehaviour
{
    public SpriteRenderer mySpriteRenderer;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            mySpriteRenderer.flipX = true;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            mySpriteRenderer.flipX = false;
        }
    }
}
