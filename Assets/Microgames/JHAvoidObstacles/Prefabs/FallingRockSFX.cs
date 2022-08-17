using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingRockSFX : MonoBehaviour
{
    bool hasMadeSound = false;
    [SerializeField] float height;
    void Update()
    {
        if (transform.position.y < height && !hasMadeSound)
        {
            hasMadeSound = true;
            GetComponentInChildren<AudioSource>().Play();
        }
    }
}
