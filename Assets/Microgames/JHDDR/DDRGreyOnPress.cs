using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DDRGreyOnPress : MonoBehaviour
{
    [SerializeField] KeyCode primary;
    [SerializeField] KeyCode secondary;
    SpriteRenderer sR;
    [SerializeField] Color[] c;
    private void Start()
    {
        sR = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        if (Input.GetKey(primary) || Input.GetKey(secondary))
        {
            sR.color = c[1];
        }
        else
        {
            sR.color = c[0];
        }
    }
}
