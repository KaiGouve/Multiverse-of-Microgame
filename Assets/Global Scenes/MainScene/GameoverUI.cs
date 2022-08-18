using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameoverUI : MonoBehaviour
{
    public void ShowGameOver(){
        GameObject.Find("GameOver-UI").SetActive(true);
    }


}

