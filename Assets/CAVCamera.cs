using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CAVCamera : MonoBehaviour
{

    [SerializeField] Transform Player;
    float offset = 3;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 temp = new Vector3(transform.position.x, Mathf.Lerp(transform.position.y, Player.position.y+offset, 0.01f),transform.position.z);
        transform.position = temp;
    }
}
