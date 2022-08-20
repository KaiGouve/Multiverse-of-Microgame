using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class NRWinner : MonoBehaviour
{
    public UnityEvent Winner;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Winner.Invoke();
        }

    }

}
