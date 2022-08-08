using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ActivateEvent : MonoBehaviour
{
    [Header("You can add delay and a second set of actions here")]
    [SerializeField] float activationDelay;
    [SerializeField] UnityEvent Instant;
    [SerializeField] UnityEvent Delayed;
    void OnEnable()
    {
        StartCoroutine(delayedInvoke());
    }

    IEnumerator delayedInvoke()
    {
        Instant.Invoke();
        yield return new WaitForSeconds(activationDelay);
        Delayed.Invoke();
    }

}
