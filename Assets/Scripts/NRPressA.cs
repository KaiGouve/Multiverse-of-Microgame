using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class NRPressA : MonoBehaviour
{
    public UnityEvent PressA;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            PressA.Invoke();
        }
    }
}
