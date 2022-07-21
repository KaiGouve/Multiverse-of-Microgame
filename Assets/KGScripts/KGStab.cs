using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KGStab : MonoBehaviour
{
    public int monsters = 13;
    public GameObject allDead;

    public void stab()
    {
      monsters--;
        if (monsters == 0) 
        {
            allDead.SetActive(true);
        }
    }
}
