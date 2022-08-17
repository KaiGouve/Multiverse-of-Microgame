using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NRWinState : MonoBehaviour
{
    public UnityEvent Winner;
    // Update is called once per frame
    private void OnTriggerEnter(Collider Player)
    {

        Winner.Invoke();

    }
}