using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.up * 0.02f;
        if (transform.position.y >= 5.3)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.tag);
        if(collision.tag == "Finish")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
