using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputExample : MonoBehaviour
{
    InputManager input;

    // List of input function:
    // accept
    // back
    // leftClick
    // rightClick
    // midClick
    // up
    // down
    // left
    // right
    // w
    // a
    // s
    // d
    // spaceBar

    void Awake()
    {
        input = (InputManager)GameObject.Find("GameManager").GetComponent(typeof(InputManager));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(input.spaceBar))
        {
             Debug.Log("Hello World!");
        }
    }
}
