using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PortalSpawn : MonoBehaviour
{
    public UnityEvent PortalAppear;
    // Update is called once per frame
    void Update()
    {

        PortalAppear.Invoke();

    }
}