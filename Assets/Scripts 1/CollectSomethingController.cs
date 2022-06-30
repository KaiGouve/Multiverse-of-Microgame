using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollectSomethingController : MonoBehaviour
{
    public GameObject[] layout;
    public GameObject player;
    bool grounded;
    public UnityEvent hasCollide;
    // Start is called before the first frame update
    void Start()
    {
        //Set Level Layout
        layout[Random.Range(0, 2)].SetActive(true);

        grounded = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (!grounded) { player.transform.Translate(0, -0.01f, 0); }
        player.transform.Translate(Input.GetAxis("Horizontal") * 0.01f, 0, 0);
    }

    void HasCollide() {
    
    }
}


