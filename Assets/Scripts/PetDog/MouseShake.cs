﻿
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseShake : MonoBehaviour
{
    float maxGauge = 100;
    [SerializeField] GaugeBar gaugeBar;
    [SerializeField] float currentGauge;
    float gaugeValue;

    [SerializeField] float maxTime = 0.1f;
    private float timer = 0;
    [SerializeField] float multiplier = 1;

    float mouseCursorSpeed;
    bool shake;
    Vector2 oldMouseAxis;
    [SerializeField] Vector2 currentMouse;

    void Update()
    {
        mouseCursorSpeed = new Vector2 (Mathf.Abs(Input.GetAxis("Mouse X")), Mathf.Abs(Input.GetAxis("Mouse Y"))).magnitude; // move speed of the mouse
        //Debug.Log(mouseCursorSpeed);

        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //if (Input.GetKey(KeyCode.Mouse0)) // If Raycast hit on the Object with the correct "Name" and right mouse click 
        if (this.GetComponent<SpriteRenderer>().bounds.Contains(mousePosition) && Input.GetKey(KeyCode.Mouse0))
        {
            Vector2 mouseAxis = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
            this.shake = Mathf.Sign(mouseAxis.x) != Mathf.Sign(this.oldMouseAxis.x) || Mathf.Sign(mouseAxis.y) != Mathf.Sign(this.oldMouseAxis.y); // If current MouseAxis position is not equal to old MouseAxis position shake is true
            this.oldMouseAxis = mouseAxis;

            //if (this.shake) Debug.Log(Time.time);

            if (timer > maxTime)
            {
                gaugeValue += mouseCursorSpeed * multiplier;
                currentGauge = Mathf.Clamp(gaugeValue, 0, maxGauge); // to clamp to maxGauge value
                
                gaugeBar.UpdateGauge((float)currentGauge / (float)maxGauge);
                timer = 0;
            }

            timer += Time.deltaTime;

        }
    }
}
