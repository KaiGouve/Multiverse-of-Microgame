using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KGCountingDirt : MonoBehaviour
{
    public int dirt = 31;
    public GameObject youWin;

    public void close()
    {
        dirt--;
        if(dirt == 0)
        {
            youWin.SetActive (true);
        }
    }

}
