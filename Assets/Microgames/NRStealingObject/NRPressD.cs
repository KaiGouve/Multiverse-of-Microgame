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
        if (Input.GetKeyDown(KeyCode.D))
        {
            PressD.Invoke();
        }
        
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            PressD.Invoke();
        }
    }
}
