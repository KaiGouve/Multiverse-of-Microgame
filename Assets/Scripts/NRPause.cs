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
            m_Pause();
        }
    }

    public void ChangeVisibility(bool activity)
    {
        currentlyPaused = !activity;

        if (!activity)
        {
            HideOnPauseObjects = GameObject.FindGameObjectsWithTag("HideOnPause");
        }
        for(int i =0; i < HideOnPauseObjects.Length; i++)
        {
            HideOnPauseObjects[i].SetActive(activity);
            
        }
        if (activity)
        {
            HideOnPauseObjects = null;
        }
        
    }

    public void m_Pause()
    {
        Time.timeScale = 0.00001f;
        Pause.Invoke();
        ChangeVisibility(false);
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        ChangeVisibility(true);
    }

}
