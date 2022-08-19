using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CAVLightScript : MonoBehaviour
{
    void Update()
    {
        transform.position = Vector2.Lerp(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition), 0.05f);
    }
}
