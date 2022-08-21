using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flipanimation : MonoBehaviour
{
    [SerializeField] SpriteRenderer sR;
    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            sR.flipX = false;
        }else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            sR.flipX = true;
        }
    }
}
