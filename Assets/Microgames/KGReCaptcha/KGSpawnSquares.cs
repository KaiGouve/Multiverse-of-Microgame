using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KGSpawnSquares : MonoBehaviour
{
    public GameObject[] spawnPoints;
    public GameObject[] things;
   
    
    
    
    // Start is called before the first frame update
    void Start()
    {

        int randomNum = Random.Range(0,12);
        for(int i = 0; i < spawnPoints.Length; i++)
        {
            int j = i + randomNum;
            if (j >= spawnPoints.Length)
            {
                j -= spawnPoints.Length;
            }
            things[j].transform.position= spawnPoints[i].transform.position;
                  
        }
    }
   
    // Update is called once per frame
    void Update()
    {
        
    }
}