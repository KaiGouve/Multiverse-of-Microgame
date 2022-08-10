using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MusicManager : MonoBehaviour
{
    int currentWorld = -1;
    float volume = 0.5f;
    [SerializeField] AudioSource[] outputs;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
            ChangeWorldMusic(0, "A");
        if(Input.GetKeyDown(KeyCode.Alpha2))
            ChangeWorldMusic(1, "A");
        if(Input.GetKeyDown(KeyCode.Alpha3))
            ChangeWorldMusic(2, "A");
        if(Input.GetKeyDown(KeyCode.Alpha4))
            ChangeWorldMusic(3, "A");
        if (Input.GetKeyDown(KeyCode.Alpha5))
            ChangeWorldMusic(4, "A");
        if (Input.GetKeyDown(KeyCode.Alpha6))
            DDRStart();


    }
    private void Start()
    {
        ChangeWorldMusic(0, "A");
    }
    public void ChangeWorldMusic(int newWorld, string game)
    {
        if (newWorld != currentWorld)
        {
            for (int i = 0; i < outputs.Length; i++)
            {
                if (i == newWorld)
                {
                    outputs[i].volume = volume;
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
        Debug.LogError("HEEEEEEEEEEEELP");
        outputs[0].volume = 0;
        outputs[1].volume = 0;
        outputs[2].volume = 0;
        outputs[3].volume = 0;
        outputs[4].volume = 0;
        outputs[5].volume = volume;
        outputs[5].PlayDelayed(0.3f);
    }
    public void DDRFail()
    {
        outputs[5].volume = 0;
    }


    public void ChangeVolume(float _volume)
    {
        volume = _volume;
        ChangeWorldMusic(currentWorld,"A");
    }


}
