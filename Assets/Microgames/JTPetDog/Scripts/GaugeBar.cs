using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GaugeBar : MonoBehaviour
{
    public Image gaugeBarFill;
    public void UpdateGauge(float fraction)
    {
        gaugeBarFill.fillAmount = fraction;
    }
}