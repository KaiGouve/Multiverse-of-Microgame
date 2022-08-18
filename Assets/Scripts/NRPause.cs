using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NRPause : MonoBehaviour
{
    public UnityEvent Pause;
    GameObject[] HideOnPauseObjects;
    bool currentlyPaused = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && Time.timeScale > 0.1)
        {

            // Pause the game
            Pause.Invoke();
            Time.timeScale = 0.00001f;
            ChangeVisibility(false);
            
        }
        else if (Time.timeScale < 0.1 && !currentlyPaused)
        {
            // Somehow broken fix
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
        currentlyPaused = !activity;
    }
    public void Resume()
    {
        Time.timeScale = 1f;
        ChangeVisibility(true);
    }

}
