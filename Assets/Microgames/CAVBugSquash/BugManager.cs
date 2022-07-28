using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BugManager : MonoBehaviour
{
    [SerializeField] GameObject bugPrefab;
    int bugs =10;
    int bugsFluc;

    Vector2 limits = new Vector2(8,4.2f);

    public UnityEvent nextScene;

    void Start()
    {
        bugsFluc = bugs;
        while (bugsFluc > 0)
        {
            GameObject bug = Instantiate(bugPrefab, new Vector3(Random.Range(-limits.x,limits.x), Random.Range(-limits.y,limits.y)), Quaternion.identity);
            bug.GetComponent<BugScript>().limits = limits;
            bug.GetComponent<BugScript>().NewGoal(Random.Range(0.1f,0.9f));
            bug.GetComponent<BugScript>().bM = this;
            bugsFluc--;
            
        }
    }
    public void clicked()
    {
        bugsFluc++;
        if (bugsFluc == bugs)
        {
            nextScene.Invoke();
            Debug.Log("WIN");
        }
    }

}
