using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollectSomethingPlayer : MonoBehaviour
{
    int coinCount = 0;
    [SerializeField] UnityEvent nextGame;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Coin")
        {
            Destroy(other.gameObject);
            coinCount++;
            if (coinCount == 5) { nextGame.Invoke(); }
        }
    }
}

        
