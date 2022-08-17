using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnimatorTriggerEvent : MonoBehaviour
{
    public bool Trigger;
    bool was;
    [SerializeField] UnityEvent triggeredEvent;

    void Update()
    {
        if (Trigger != was)
        {
            if (Trigger)
            {
                triggeredEvent.Invoke();
            }
            was = Trigger;
        }
    }
}
