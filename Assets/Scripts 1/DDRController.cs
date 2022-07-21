using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DDRController : MonoBehaviour
{
    // SONG USED IN THIS GAME MUST BE 120bpm
    public Transform[] markers;
    public GameObject arrow;
    GameObject[] arrowSequence;
    int beatLimit = 16;
    int beatShape;
    int counter = -1;
    float speed;
    Vector3 startPoint;
    // Start is called before the first frame update
    void Start()
    {
        arrowSequence = new GameObject[beatLimit];
        for(var i = 0; i < beatLimit; i++) {
            beatShape = Random.Range(0, 4);
            startPoint = new Vector3(markers[beatShape].position.x + 15, markers[beatShape].position.y, 0);
            arrowSequence[i] = Instantiate(arrow, startPoint, Quaternion.identity);
        }
        speed = Mathf.Abs((startPoint.x - markers[0].position.x) / (60 * 4));
        StartCoroutine(BeatTimer());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        for (var i = 0; i < beatLimit; i ++) {
            if (counter >= i) {
                arrowSequence[i].transform.Translate(-speed, 0, 0);
            }
        }

        
    }

    IEnumerator BeatTimer() {
        yield return new WaitForSeconds(0.5f);
        counter ++;
        StartCoroutine(BeatTimer());
        
    }
}
