using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CAVBullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.up * 10f*Time.deltaTime;
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
            GetComponent<AudioSource>().Play();
            transform.position = new Vector3(-20,-20,0);
            StartCoroutine(delayed());
            
        }
    }
    IEnumerator delayed()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
        GameObject.Find("Gun").GetComponent<CAVGunScript>().dead();
    }
}
