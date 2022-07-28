using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KGAnswerSpawn : MonoBehaviour
{
    public GameObject[] spawnPoints;
    public GameObject[] answers;




    // Start is called before the first frame update
    void Start()
    {

        int randomNum = Random.Range(0, 2);
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            int j = i + randomNum;
            if (j >= spawnPoints.Length)
            {
                j -= spawnPoints.Length;
            }
            answers[j].transform.position = spawnPoints[i].transform.position;

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
