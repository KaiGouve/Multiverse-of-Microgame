using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class SpotTheDifferenceController : MonoBehaviour
{
    public GameObject[] spotting;
    public Color[] cols;
    Color getCol;
    int notIn;
    float[] xSpeed;
    float[] ySpeed;
    public UnityEvent nextScene;
    public UnityEvent loss;
    // Start is called before the first frame update
    void Start()
    {
        xSpeed = new float[spotting.Length];
        ySpeed = new float[spotting.Length];

        // Set speed values per instance
        for(var i = 0; i < xSpeed.Length; i++) {
            xSpeed[i] = Random.Range(-0.01f, 0.01f);
            ySpeed[i] = Random.Range(-0.01f, 0.01f);
        }

        // Set colour calues per instance and identify odd one out
        var selected = Random.Range(0, spotting.Length);
        notIn = Random.Range(0, cols.Length);
        var buffer = 0;
        for(var z = 0; z < spotting.Length; z++){
            if (z != selected) {
                spotting[z].GetComponent<Image>().color = cols[buffer];
            } 
            else {spotting[z].GetComponent<Image>().color = cols[notIn];}
            if (buffer > 7) {buffer = 0;} else {buffer ++;}
            if (buffer == notIn) {
                if (buffer + 1 < 8) {buffer ++;} else {buffer = 0;}
            }
        }
        getCol = spotting[selected].GetComponent<Image>().color;
    }

    // Update is called once per frame
    void Update()
    {
        for(var i = 0; i < spotting.Length; i++) {
            spotting[i].transform.Translate(xSpeed[i], ySpeed[i], 0);
            if (spotting[i].transform.position.x >= 8.5f) {
                xSpeed[i] = -xSpeed[i];
            } else if (spotting[i].transform.position.x <= -8.5f) {
                xSpeed[i] = -xSpeed[i];
            }

            if (spotting[i].transform.position.y >= 5f) {
                ySpeed[i] = -ySpeed[i];
            } else if (spotting[i].transform.position.y <= -5f) {
                ySpeed[i] = -ySpeed[i];
            }
        }
    }

    public void SpotMe(){
        if (UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.GetComponent<Image>().color == getCol) {
            {Debug.Log("You Win!");} // Win State
            nextScene.Invoke();
        } else {
            {Debug.Log("You Lose!");} // Lose State
            loss.Invoke();
        }
    }
}
