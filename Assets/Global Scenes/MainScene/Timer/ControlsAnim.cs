using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlsAnim : MonoBehaviour
{
    [SerializeField] Sprite[] Images;
    int number;
    [SerializeField] float delay;
    [SerializeField] bool mouseJiggle;
    Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("fY");
        startPos = transform.position;
    }

    IEnumerator fY()
    {
        yield return new WaitForSeconds(delay);
        number++;
        number = number==Images.Length? 0:number;
        GetComponent<Image>().sprite = Images[number];
        StartCoroutine("fY");
    }

    private void FixedUpdate()
    {
        if (mouseJiggle)
        {
            transform.position = startPos + new Vector3(Mathf.Sin(Time.time*10)*15, Mathf.Cos(Time.time * 10) * 15);
        }
    }
}
