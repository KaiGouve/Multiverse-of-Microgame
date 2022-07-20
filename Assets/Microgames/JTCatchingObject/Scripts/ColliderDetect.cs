using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ColliderDetect : MonoBehaviour
{
    public string objectCollider;
    GameObject collide;

    public DetectGameObject detectType;

    public UnityEvent detectObj;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collide = collision.gameObject;

        if (collide.name == $"{objectCollider}" && collide != null)
        {
            detectObj.Invoke();

            switch (detectType)
            {
                case DetectGameObject.None:
                    break;
                case DetectGameObject.SetActiveFalse:
                    collide.SetActive(false);
                    break;
                case DetectGameObject.SetActiveTrue:
                    collide.SetActive(true);
                    break;
                case DetectGameObject.Destroy:
                    Destroy(collide);
                    break;
            }
        }
    }
}

public enum DetectGameObject
{
    None,
    SetActiveFalse,
    SetActiveTrue,
    Destroy
}
