using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CAVEnemyScript : MonoBehaviour
{
    public UnityEvent invokeApply;

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.down * 2f * Time.deltaTime;
        if (transform.position.y <= -4.3f)
        {
            //loss
            GameObject.Find("Gun").GetComponent<CAVGunScript>().fail.Invoke();
            GameObject[] planes = GameObject.FindGameObjectsWithTag("Finish");
            foreach(GameObject plane in planes)
            {
                Destroy(plane);
            }
        }
    }

    public void failInvoke()
    {
        GameObject.Find("Gun").GetComponent<CAVGunScript>().fail.Invoke();
    }
}
