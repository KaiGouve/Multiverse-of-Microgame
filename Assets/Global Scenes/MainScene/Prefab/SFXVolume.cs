using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXVolume : MonoBehaviour
{
    private void OnEnable()
    {
        GetComponent<AudioSource>().volume = GameObject.FindGameObjectWithTag("WorldManager").GetComponent<MusicManager>().currentSFXVolume();
    }
}
