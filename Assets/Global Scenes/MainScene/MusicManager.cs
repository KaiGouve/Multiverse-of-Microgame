using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MusicManager : MonoBehaviour
{
    int currentWorld = -1;
    int volume = 1;
    [SerializeField] AudioSource[] outputs;

    private void Update()
    {
        
    }
    public void ChangeWorldMusic(int newWorld, string game)
    {
        Debug.LogError("A");
        if (newWorld != currentWorld)
        {
            Debug.LogError("B");
            for (int i = 0; i < outputs.Length; i++)
            {
                Debug.LogError("C");
                if (i == newWorld)
                {
                    Debug.LogError("D " + i);
                    outputs[i].volume = volume;
                }
                else
                {
                    Debug.LogError("E " + i);
                    outputs[i].volume = 0;
                }
            }
            currentWorld = newWorld;
        }
        Debug.Log(game);
        if (game == "DDR")
        {
            DDRStart();
        }
    }
    public void DDRStart()
    {
        Debug.LogError("HEEEEEEEEEEEELP");
    }


    void ChangeVolume()
    {

    }


}
