using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    [SerializeField] float currentTime = 0f;
    [SerializeField] float setTime = 10f;
    [SerializeField] bool downOrUp = false;

    [SerializeField] Text countText;

    float multiplier = 1;

    bool callOnce = true;

    public UnityEvent startTime;
    public UnityEvent endTime;

    void Start()
    {
        startTime.Invoke();
        if (downOrUp == false)
        {
            currentTime = setTime;
        }
    }

    private void Update()
    {
        if (downOrUp == false)
        {
            currentTime -= 1 * Time.deltaTime * multiplier;

            if (countText != null)
            {
                countText.text = currentTime.ToString("0");
            }

            if (currentTime <= 0)
            {
                currentTime = 0;
            }

            if (currentTime == 0)
            {
                if (callOnce)
                {
                    callOnce = false;
                    endTime.Invoke();
                }
            }
        }
        else
        {
            currentTime += 1 * Time.deltaTime * multiplier;

            if (countText != null)
            {
                countText.text = currentTime.ToString("0");
            }

            if (currentTime >= setTime)
            {
                currentTime = setTime;
                endTime.Invoke();
            }

            if (currentTime == setTime)
            {
                if (callOnce)
                {
                    callOnce = false;
                    endTime.Invoke();
                }
            }
        }
    }

    public void SpeedMultiplier()
    {
        if (Time.timeScale <= 0.00001f)
        {
            StartCoroutine(MaxSpeed());
        }
    }

    IEnumerator MaxSpeed()
    {
        yield return new WaitForSeconds(0.00001f);
        multiplier = 100000;
    }

    public void ReturnMultiplier()
    {
        multiplier = 1;
    }

    public void StopTime()
    {
        //Time.timeScale = 0;
        Time.timeScale = 0.00001f;
    }

    public void ContinueTime()
    {
        Time.timeScale = 1;
    }
}
