using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ActivateEvent : MonoBehaviour
{
    [SerializeField] UnityEvent Activate;
    void OnEnable()
    {
        Activate.Invoke();
    }

}
