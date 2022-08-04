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
    int bpm = 120;
    int note = 2;
    float bps;
    int trackBeat = 0;
    bool canBeat = false;
    int keepCount = 1;
    int time = 0;
    float speed;
    int dist = 15;
    Vector3 startPoint;
    public int successful=0;
    float antiCheatTimer = 0;
    float antiCheatCounter;

    // Start is called before the first frame update
    void Start()
    {
        bps = bpm / note;
        arrowSequence = new GameObject[beatLimit];
        for(var i = 0; i < beatLimit; i++) {
            beatShape = Random.Range(0, 4);
            startPoint = new Vector3(markers[beatShape].position.x + dist, markers[beatShape].position.y, 0);
            arrowSequence[i] = Instantiate(arrow, startPoint, Quaternion.identity);
            arrowSequence[i].GetComponent<DDRArrowScript>().DDRC = this;
        }
        speed = dist / (bps * 2);
        StartCoroutine(BeatTimer());
    }

    void FixedUpdate()
    {
        for (var i = 0; i < beatLimit; i ++) {
            if (counter >= i) {
                arrowSequence[i].transform.position += new Vector3(-speed, 0, 0);
            }
        }

        // Track Rhythm
        time ++;
        if (time/60 >= 0 + (trackBeat * bps)) {
            canBeat = true;
            trackBeat ++;
            // if keepCount != 16 keepCount++ else keepCount = 1;
        } else canBeat = false;
        
        // Start On Beat
        // if keepCouint == 1 moveArrow

        if(successful== beatLimit)
        {
            //WINSTATE
            Debug.LogError("WIN");
            successful++;
        }


    }

    private void Update()
    {
        //Anticheat
        antiCheatTimer += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.S))
        {
            antiCheatCounter++;
        }
        if (antiCheatTimer >= 0.5f)
        {
            //check how many inputs
            if (antiCheatCounter > 4)
            {
                //probably cheating idk what to do if they are tho rn.
                Debug.LogWarning("cheating");

            }

            antiCheatTimer -= 0.5f;
            antiCheatCounter = 0;
        }


    }


    IEnumerator BeatTimer() {
        yield return new WaitForSeconds(0.5f);
        counter ++;
        StartCoroutine(BeatTimer());
        
    }
}
