using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpotTheDifferenceController : MonoBehaviour
{
    public GameObject[] spotting;
    public Color[] cols;
    int notIn;
    // Start is called before the first frame update
    void Start()
    {
        var i = 0;
        notIn = (Random.Range(0, cols.Length));
        foreach(GameObject box in spotting) {
            box.GetComponent<SpriteRenderer>().color = cols[i];
            i ++;
            if (i == notIn) i++;
            if (i == 9) i = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
