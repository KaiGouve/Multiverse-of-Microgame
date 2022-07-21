using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CAVCarScript : MonoBehaviour
{
    [SerializeField] Vector2 Direction;
    Vector3 pos;
    private Rigidbody2D rb;
    Vector3 offset = Vector2.zero;
    bool thisCar = false;
    Vector2 centre;
    Vector3 diff;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        centre = new Vector2(findCentre(Direction.x), findCentre(Direction.y));
    }


    float findCentre (float a)
    {
        float b = (a - 1) / 2;
        return b > 0 ? b : 0;
    }


    private void OnMouseUp()
    {
        Debug.Log("up");
        thisCar = false;
    }
    private void OnMouseDown()
    {
        Debug.Log("down");
        offset = Diff();
        thisCar = true;
    }

    private void Update()
    {/*
        pos = transform.position + centre;


        *//*
        if (!Input.GetKey(KeyCode.Mouse0)&& diffToRound(transform.position)<=0.02f&& rb.velocity.magnitude!=0&& thisCar)
        {
            if(diffToRound(transform.position) <= 0.02f)
            {
                rb.velocity = Vector2.zero;
                thisCar = false;
                Debug.LogWarning("dropped piece " + this);
               // transform.position = new Vector3(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y), -3);
            }
            
        }*/
        if( rb.velocity.magnitude!=0 & !thisCar)
        {
            checkSnap();
        }

        if (thisCar)
        {
            diff = Direction.normalized * (Diff() - offset);
            rb.velocity = diff * Time.deltaTime * 1000;
        }


    }

    void checkSnap()
    {

        Vector3 c = transform.position + (Vector3)centre;

        Debug.LogError(c);

        if (diffToRound(c) <= 0.05)
        {
            Debug.LogWarning("STOP");
            stopMovement();
        }


    }

    void stopMovement()
    {
        rb.velocity = Vector3.zero;
        Vector3 d = transform.position + (Vector3)centre;
        Vector3 e = new Vector3(Mathf.Round(d.x), Mathf.Round(d.y), d.z);
        transform.position = e - (Vector3)centre;
    }

    float diffToRound(Vector3 h)
    {
        Debug.Log(Mathf.Abs((h.x - Mathf.Round(h.x)) * Direction.x + (h.y - Mathf.Round(h.y))) * Direction.y);
        Debug.LogError($"{h.x} + {h.y}");
        return Mathf.Abs(Mathf.Abs((h.x - Mathf.Round(h.x)) * Direction.x + (h.y - Mathf.Round(h.y))) * Direction.y);
        

    }
    Vector3 Diff()
    {
        return mousePos() - transform.position;
    }


    Vector3 mousePos()
    {
        return FTR(Camera.main.ScreenToWorldPoint(Input.mousePosition));
    }
    Vector3 FTR(Vector3 input)
    {
        return input - new Vector3(2f,2f);
    }

}
