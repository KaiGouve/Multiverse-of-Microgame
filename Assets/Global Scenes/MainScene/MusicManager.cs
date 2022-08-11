using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour
{
    int currentWorld = -1;
    float f_mVolume = 0.33f;
    float f_sfxVolume = 0.66f;
    [SerializeField] AudioSource[] outputs;

    [SerializeField] Slider s_vSFX;
    [SerializeField] Slider s_vMusic;


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
            ChangeWorldMusic(0);
        if(Input.GetKeyDown(KeyCode.Alpha2))
            ChangeWorldMusic(1);
        if(Input.GetKeyDown(KeyCode.Alpha3))
            ChangeWorldMusic(2);
        if(Input.GetKeyDown(KeyCode.Alpha4))
            ChangeWorldMusic(3);
        if (Input.GetKeyDown(KeyCode.Alpha5))
            ChangeWorldMusic(4);
        if (Input.GetKeyDown(KeyCode.Alpha6))
            DDRStart();


    }
    private void Start()
    {
        s_vSFX.value = f_sfxVolume;
        s_vSFX.SetValueWithoutNotify(f_sfxVolume);
        s_vMusic.SetValueWithoutNotify(f_mVolume);

        ChangeWorldMusic(0);
        ChangeSFXVolume();
        ChangeMusicVolume();
    }
    public void ChangeWorldMusic(int newWorld)
    {
        if (newWorld != currentWorld)
        {
            for (int i = 0; i < outputs.Length; i++)
            {
                if (i == newWorld)
                {
                    outputs[i].volume = f_mVolume;
                }
                else
                {
                    outputs[i].volume = 0;
                }
            }
            currentWorld = newWorld;
        }
    }
    public void DDRStart()
    {
        currentWorld = 5;
        outputs[0].volume = 0;
        outputs[1].volume = 0;
        outputs[2].volume = 0;
        outputs[3].volume = 0;
        outputs[4].volume = 0;
        outputs[5].volume = f_mVolume;
        outputs[5].PlayDelayed(0.3f);
    }
    public void DDRFail()
    {
        outputs[5].volume = 0;
    }


    public void ChangeMusicVolume()
    {
        f_mVolume = s_vMusic.value;
        ChangeWorldMusic(currentWorld);
    }
    public void ChangeSFXVolume()
    {
        f_mVolume = s_vMusic.value;
        GameObject[] SFX = GameObject.FindGameObjectsWithTag("SFX");
        foreach(GameObject _SFX in SFX)
        {
            _SFX.GetComponent<AudioSource>().volume = f_sfxVolume;
        }
    }


}