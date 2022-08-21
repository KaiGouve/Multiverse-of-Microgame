using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnyKeyEvent : MonoBehaviour
{
    [SerializeField] UnityEvent Event;


    void Update()
    {
        if (Input.anyKey)
        {
            Event.Invoke();
            Debug.Log(Time.deltaTime);
            enabled = false;
        }
    }
}
