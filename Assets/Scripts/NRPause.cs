using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NRPause : MonoBehaviour
{
    public UnityEvent Pause;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            Pause.Invoke();
            Time.timeScale = 0.00001f;
        }
    }
}
