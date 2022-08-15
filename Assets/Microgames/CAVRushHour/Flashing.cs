using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashing : MonoBehaviour
{
    SpriteRenderer sR;
    [SerializeField]Color[] cA;
    int i = 0;

    // Start is called before the first frame update
    void Start()
    {
        sR = GetComponent<SpriteRenderer>();
        StartCoroutine(flasher());
    }

    IEnumerator flasher()
    {
        yield return new WaitForSeconds(0.8f);
        i = i == 1 ? 0 : 1;
        sR.color = cA[i];
        StartCoroutine(flasher());
    }
}
