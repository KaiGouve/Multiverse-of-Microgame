using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXVolume : MonoBehaviour
{
    public float multiplier;
    private void OnEnable()
    {
        multiplier = GetComponent<AudioSource>().volume;
        GetComponent<AudioSource>().volume = GameObject.FindGameObjectWithTag("WorldManager").GetComponent<MusicManager>().currentSFXVolume()*multiplier;
    }
}
