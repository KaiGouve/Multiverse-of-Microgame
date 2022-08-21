using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NRCamera : MonoBehaviour
{
    [SerializeField] GameObject player;

    void Update()
    {
        if(player.activeSelf){
            transform.position = new Vector3(Mathf.Lerp(transform.position.x,Mathf.Clamp(player.transform.position.x,0,33),0.1f),transform.position.y,transform.position.z);
        }
        
    }
}
