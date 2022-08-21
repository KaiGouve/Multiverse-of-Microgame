using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EscKey : MonoBehaviour
{
    [SerializeField] UnityEvent Event;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Event.Invoke();
        }
    }

}
