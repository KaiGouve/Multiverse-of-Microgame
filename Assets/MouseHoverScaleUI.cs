using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseHoverScaleUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject target;
    public Vector3 targetReposition = new Vector3(1f, 1f, 1f);
    public Vector3 targetRerotation = new Vector3(1f, 1f, 1f);
    public Vector3 targetResize = new Vector3(1f,1f,1f);
    public float speed = 10f;

    Vector3 targetOriginalPosition;
    Vector3 targetOriginalRotation;
    Vector3 targetOriginalSize;

    private bool mouse_over = false;

    private void Awake()
    {
        targetOriginalPosition = target.transform.localPosition;
        targetOriginalRotation = new Vector3(target.transform.localRotation.x, target.transform.localRotation.y, target.transform.localRotation.z);
        targetOriginalSize = target.transform.localScale;
    }

    void Update()
    {
        if (mouse_over)
        {
            // Debug.Log("Mouse Over");

            target.transform.localPosition = Vector3.Lerp(target.transform.localPosition, targetReposition, speed * Time.deltaTime);
            target.transform.localRotation = Quaternion.Lerp(target.transform.localRotation, Quaternion.Euler(targetRerotation), speed * Time.deltaTime);
            target.transform.localScale = Vector3.Lerp(target.transform.localScale, targetResize, speed * Time.deltaTime);
        }
        else
        {
            target.transform.localPosition = Vector3.Lerp(target.transform.localPosition, targetOriginalPosition, speed * Time.deltaTime);
            target.transform.localRotation = Quaternion.Lerp(target.transform.localRotation, Quaternion.Euler(targetOriginalRotation), speed * Time.deltaTime);
            target.transform.localScale = Vector3.Lerp(target.transform.localScale, targetOriginalSize, speed * Time.deltaTime);
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
