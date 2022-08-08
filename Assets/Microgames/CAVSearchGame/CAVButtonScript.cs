using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CAVButtonScript : MonoBehaviour
{
    public bool real = false;

    private void OnMouseDown()
    {
        if (real)
        {
            GameObject.Find("Manager").GetComponent<CAVManagerScript>().nextScene.Invoke();
        }
        else
        {
            GameObject.Find("Manager").GetComponent<CAVManagerScript>().fail.Invoke();
        }
    }
}
