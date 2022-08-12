using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugScript : MonoBehaviour
{
    float progress;
    float speed;
    float flucSpeed;
    public Vector2 limits;
    Vector3 goal;
    Vector3 old;
    public BugManager bM;

    [SerializeField] Sprite[] bugs;

    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = bugs[Random.Range(0, bugs.Length)];
    }
    public void NewGoal(float a)
    {
        old = transform.position;
        goal = new Vector3(Random.Range(-limits.x, limits.x), Random.Range(-limits.y, limits.y));
        flucSpeed = Random.Range(0.1f,0.5f);
        progress = a;
        //

        Vector3 targ = goal;
        targ.z = 0f;

        targ -= transform.position;

        float angle = Mathf.Atan2(targ.y, targ.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
    private void Update()
    {
        if (progress > 1)
            progress = 1;

        transform.position = Vector3.Lerp(old, goal, progress);

        if (progress == 1)
        {
            NewGoal(0);
        }
        else
        {
            progress += Time.deltaTime * flucSpeed;
        }
        
    }
    private void OnMouseDown()
    {
        bM.clicked();
        GetComponent<AudioSource>().Play();
        Destroy(gameObject);
    }
}
