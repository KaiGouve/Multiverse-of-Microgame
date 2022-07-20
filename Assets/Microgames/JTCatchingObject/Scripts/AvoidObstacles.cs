using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvoidObstacles : MonoBehaviour
{
    public Vector3[] spawners;
    public GameObject obstacle;

    [SerializeField] float speed = 1f;

    public GameObject player;
    GameObject[] falling;
    [SerializeField, ReadOnly] int spawnAmount = 20;
    [SerializeField, ReadOnly] int counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        falling = new GameObject[spawnAmount];
        for (var i=0; i < spawnAmount; i++) {
            if (i == 0) falling[i] = Instantiate(obstacle, new Vector3(player.transform.position.x, 6, 0), Quaternion.identity);
            else falling[i] = Instantiate(obstacle, spawners[Random.Range(0, spawners.Length)], Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (var i = 0; i < spawnAmount; i ++) {
            if (counter >= i) {
                falling[i].transform.Translate(0, -0.013f * speed, 0);
            }
            if (falling[counter].transform.position.y < 2 && counter < spawnAmount - 1) {
                counter ++;
            } 
        }
    }
}
