using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DetectCount : MonoBehaviour
{
    [SerializeField] int expectCount;
    [SerializeField, ReadOnly] int currentCount;

    public UnityEvent CountExpect;

    void Update()
    {
        if (currentCount == expectCount)
        {
            CountExpect.Invoke();
            currentCount++;
        }
    }
    public void DetectCountNumber()
    {
        ++currentCount;
    }
}
