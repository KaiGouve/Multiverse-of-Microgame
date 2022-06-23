using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsticalSpawner : MonoBehaviour
{
    public float maxTime = 1;
    private float timer = 0;
    public GameObject obstical;
    public float height;

    // Start is called before the first frame update
    void Start()
    {
        GameObject newObstical = Instantiate(obstical);
        newObstical.transform.position = transform.position + new Vector3(0, Random.Range(-height, height), 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > maxTime)
        {
            GameObject newObstical = Instantiate(obstical);
            newObstical.transform.position = transform.position + new Vector3(0, Random.Range(-height, height), 0);
            Destroy(newObstical, 15);
            timer = 0;
        }

        timer += Time.deltaTime;
    }
}
