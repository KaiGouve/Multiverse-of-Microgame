using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsticalMove : MonoBehaviour
{
    public ObjMove objMove;
    public float speed = 1;

    // Update is called once per frame
    void Update()
    {
        switch (objMove)
        {
            case ObjMove.UP:
                transform.position += Vector3.up * speed * Time.deltaTime;
                break;
            case ObjMove.DOWN:
                transform.position += Vector3.down * speed * Time.deltaTime;
                break;
            case ObjMove.LEFT:
                transform.position += Vector3.left * speed * Time.deltaTime;
                break;
            case ObjMove.RIGHT:
                transform.position += Vector3.right * speed * Time.deltaTime;
                break;
        }
    }
}

public enum ObjMove
{ 
    UP,
    DOWN,
    LEFT,
    RIGHT
}