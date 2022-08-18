using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsticalSpawner : MonoBehaviour
{
    public float maxTime = 1;
    private float timer = 0;
    public GameObject obstical;
    public float verticalH;
    public float horizontalH;

    // Start is called before the first frame update
    void Start()
    {
        GameObject newObstical = Instantiate(obstical);

        newObstical.transform.position = transform.position + new Vector3(Random.Range(-horizontalH, horizontalH), Random.Range(-verticalH, verticalH), 1.2f);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > maxTime)
        {
            GameObject newObstical = Instantiate(obstical);

            newObstical.transform.position = transform.position + new Vector3(Random.Range(-horizontalH, horizontalH), Random.Range(-verticalH, verticalH), 1.2f);

            Destroy(newObstical, 15);
            timer = 0;
        }

        timer += Time.deltaTime;
    }
}
