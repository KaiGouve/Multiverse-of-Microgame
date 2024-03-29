using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CAVEnemyScript : MonoBehaviour
{
    public UnityEvent invokeApply;
    public CAVGunScript gS;

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.down * 2f * Time.deltaTime;
        if (transform.position.y <= -4.3f)
        {
            //loss
            GameObject.Find("Gun").GetComponent<CAVGunScript>().fail.Invoke();
            gS.clear();
            
        }
    }

    public void failInvoke()
    {
        GameObject.Find("Gun").GetComponent<CAVGunScript>().fail.Invoke();
    }
}
