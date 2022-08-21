using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class TitleEnd : MonoBehaviour

{
    public UnityEvent EndTitle;
    // Update is called once per frame
    void Update()
    {

        EndTitle.Invoke();

    }
}