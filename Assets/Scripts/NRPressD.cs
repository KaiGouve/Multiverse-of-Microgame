using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class NRPressD : MonoBehaviour
{
    public UnityEvent PressD;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            PressD.Invoke();
        }
    }
}
