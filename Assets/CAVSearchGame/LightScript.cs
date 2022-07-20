using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        toggleMouseVisibility();
    }
    void toggleMouseVisibility()
    {
        Cursor.visible = !Cursor.visible;
    }


    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.Lerp(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition), 0.05f);
    }
}
