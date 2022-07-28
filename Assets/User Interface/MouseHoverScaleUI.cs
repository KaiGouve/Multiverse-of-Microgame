using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseHoverScaleUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject targetSize;
    public Vector3 targetResize;
    public float speed;
    Vector3 targetOriginalSize;

    private bool mouse_over = false;

    private void Awake()
    {
        targetOriginalSize = targetSize.transform.localScale;
    }

    void Update()
    {
        if (mouse_over)
        {
            // Debug.Log("Mouse Over");
            targetSize.transform.localScale = Vector3.Lerp(targetSize.transform.localScale, targetResize, speed * Time.deltaTime);
        }
        else
        {
            targetSize.transform.localScale = Vector3.Lerp(targetSize.transform.localScale, targetOriginalSize, speed * Time.deltaTime);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        mouse_over = true;
        // Debug.Log("Mouse enter");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        mouse_over = false;
        // Debug.Log("Mouse exit");
    }
}
