using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CreditEnd : MonoBehaviour
{
    public UnityEvent EndCredit;
    // Update is called once per frame
    void Update()
    {

        EndCredit.Invoke();

    }
}