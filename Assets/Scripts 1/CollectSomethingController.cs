using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollectSomethingController : MonoBehaviour
{
    public GameObject[] layout;
    public GameObject player;
    bool grounded;
    // Start is called before the first frame update
    void Start()
    {
        //Set Level Layout
        layout[Random.Range(0, 2)].SetActive(true);
;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Input.GetAxis("Horizontal") * 0.01f, 0, 0);
    }
}


