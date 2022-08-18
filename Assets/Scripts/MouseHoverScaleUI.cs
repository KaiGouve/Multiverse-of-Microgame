using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class MouseHoverScaleUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject targetSize;
    public Vector3 targetResize;
    public float speed;
    Vector3 targetOriginalSize;
    public float multiplier = 1;

    [SerializeField] UnityEvent hoverEvent;
    [SerializeField] UnityEvent unHoverEvent;

    public AudioSource hoverSound;

    private bool mouse_over = false;

    private void Awake()
    {
        targetOriginalSize = targetSize.transform.localScale;
    }

    void Update()
    {
        if (Time.timeScale<0.5f)
        {
            multiplier = 10000;    
        }
        else
        {
            multiplier = 1;
        }
        if (mouse_over)
        {
            // Debug.Log("Mouse Over");
            targetSize.transform.localScale = Vector3.Lerp(targetSize.transform.localScale, targetResize, speed * Time.deltaTime * multiplier);
        }
        else
        {
            targetSize.transform.localScale = Vector3.Lerp(targetSize.transform.localScale, targetOriginalSize, speed * Time.deltaTime * multiplier);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        mouse_over = true;
        // Debug.Log("Mouse enter");
        if(hoverSound != null)
            hoverSound.Play();
        hoverEvent.Invoke();

        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        mouse_over = false;
        // Debug.Log("Mouse exit");
        if (hoverSound != null)
            hoverSound.Stop();
        unHoverEvent.Invoke();
    }
    private void OnDisable()
    {
        targetSize.transform.localScale = targetOriginalSize;
    }
}
