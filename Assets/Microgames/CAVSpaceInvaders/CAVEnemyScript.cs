using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CAVEnemyScript : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.down * 0.5f * Time.deltaTime;
        if (transform.position.y <= -4.3f)
        {
            //loss
            GameObject.Find("Gun").GetComponent<CAVGunScript>().fail.Invoke();
        }
    }
}
