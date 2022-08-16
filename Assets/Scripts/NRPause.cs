using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NRPause : MonoBehaviour
{
    public UnityEvent Pause;
    GameObject[] HideOnPauseObjects;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && Time.timeScale > 0.1)
        {
            Pause.Invoke();
            Time.timeScale = 0.00001f;
            ChangeVisibility(false);
        }
        else if (Time.timeScale > 0.1)
        {
            ChangeVisibility(true);
        }
    }

    public void ChangeVisibility(bool activity)
    {
        if (!activity)
        {
            HideOnPauseObjects = GameObject.FindGameObjectsWithTag("HideOnPause");
        }
        for(int i =0; i < HideOnPauseObjects.Length; i++)
        {
            HideOnPauseObjects[i].SetActive(activity);
        }
    }


}
