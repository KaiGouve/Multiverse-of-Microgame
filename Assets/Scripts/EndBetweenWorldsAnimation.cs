using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EndBetweenWorldsAnimation : MonoBehaviour
{
    public UnityEvent EndAnimation;
    // Update is called once per frame
    void Update()
    {

        EndAnimation.Invoke();

    }
}