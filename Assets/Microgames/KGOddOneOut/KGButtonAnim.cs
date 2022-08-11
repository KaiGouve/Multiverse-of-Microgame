using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KGButtonAnim : MonoBehaviour
{
    [SerializeField] Sprite[] Images;
    int number;
    [SerializeField] float delay;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("fuckYou");
    }

    IEnumerator fuckYou()
    {
        yield return new WaitForSeconds(delay);
        number++;
        number = number==Images.Length? 0:number;
        GetComponent<Image>().sprite = Images[number];
        StartCoroutine("fuckYou");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
