using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class NRLoser : MonoBehaviour
{
    public UnityEvent Loser;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Loser.Invoke();
        }
    }

}
