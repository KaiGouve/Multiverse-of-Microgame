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
            //win
            Debug.Log("won");
        }
        else
        {
            //fail
            Debug.Log("failed");
        }
    }
}
