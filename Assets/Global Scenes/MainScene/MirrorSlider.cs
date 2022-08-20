using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MirrorSlider : MonoBehaviour
{
    [SerializeField] Slider otherSlider;

    [SerializeField] Slider thisSlider;

    [SerializeField] MusicManager mM;

    [SerializeField] bool sfx;

    private void OnEnable()
    {
        thisSlider.value = otherSlider.value;
    }
    public void changeVolume()
    {
        otherSlider.value = thisSlider.value;
        if (sfx)
        {
            mM.ChangeSFXVolume();
        }
        else
        {
            mM.ChangeMusicVolume();
        }
    }

}
