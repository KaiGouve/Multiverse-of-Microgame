using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MalletScript : MonoBehaviour
{
    private void Update()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition)+new Vector3(0.5f,-0.2f, 10);
        if (Input.GetKey(KeyCode.Mouse0))
        {
            transform.rotation = transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(new Vector3(0, 0, 45)), Time.deltaTime*30);
        }
        else
        {
            transform.rotation = Quaternion.Euler(Vector3.zero);
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GetComponent<AudioSource>().Play();
        }
    }


    void Start()
    {
        Cursor.visible = false;
    }

    private void OnDisable()
    {
        Cursor.visible = true;
    }
}
