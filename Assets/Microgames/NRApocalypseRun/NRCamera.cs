using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NRCamera : MonoBehaviour
{
    [SerializeField] GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player.activeSelf){
            transform.position = new Vector3(Mathf.Lerp(transform.position.x,player.transform.position.x,0.1f),transform.position.y,transform.position.z);
        }
        
    }
}
