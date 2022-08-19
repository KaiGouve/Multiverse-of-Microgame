using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CAVButtonScript : MonoBehaviour
{
    public bool real = false;


    private void Update()
    {
        transform.localScale = real? new Vector3(4, 4, 1) : new Vector3(2,2,1);
    }

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
