using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollisionOver : MonoBehaviour
{
    public UnityEvent detectObj;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        detectObj.Invoke(); // Game Over
    }
}
