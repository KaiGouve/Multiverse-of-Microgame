
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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
    [SerializeField] Vector2 currentMouse;

    public UnityEvent nextScene;

    void Update()
    {
        mouseCursorSpeed = new Vector2 (Mathf.Abs(Input.GetAxis("Mouse X")), Mathf.Abs(Input.GetAxis("Mouse Y"))).magnitude; // move speed of the mouse
        //Debug.Log(mouseCursorSpeed);

        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //if (Input.GetKey(KeyCode.Mouse0)) // If Raycast hit on the Object with the correct "Name" and right mouse click 
        if (this.GetComponent<SpriteRenderer>().bounds.Contains(mousePosition) && Input.GetKey(KeyCode.Mouse0))
        {
            if (timer > maxTime)
            {
                gaugeValue += mouseCursorSpeed * multiplier;
                currentGauge = Mathf.Clamp(gaugeValue, 0, maxGauge); // to clamp to maxGauge value
                
                gaugeBar.UpdateGauge((float)currentGauge / (float)maxGauge);
                timer = 0;
            }
            timer += Time.deltaTime;
        }

        if (currentGauge == maxGauge)
        {
            nextScene.Invoke();
            Debug.Log("NextScene");
        }
    }
}
