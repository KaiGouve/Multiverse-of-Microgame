using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingRockSFX : MonoBehaviour
{
    bool hasMadeSound = false;
    void Update()
    {
        if (transform.position.y < 8 && !hasMadeSound)
        {
            hasMadeSound = true;
            GetComponentInChildren<AudioSource>().Play();
        }
    }
}
