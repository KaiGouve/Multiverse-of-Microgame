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
    Vector3 moved;
    [SerializeField] bool redCar;

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
    {
        moved = transform.position + (Vector3)centre;


        if ( rb.velocity.magnitude!=0 & !thisCar)
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
        if (diffToRound() <= 0.2)
        {
            stopMovement();
        }


    }

    void stopMovement()
    {
        rb.velocity = Vector3.zero;
        Vector3 e = new Vector3(Mathf.Round(moved.x), Mathf.Round(moved.y), moved.z);
        transform.position = e - (Vector3)centre;

        if (transform.position.x >= 2.5)
        {
            Debug.LogError("WIN");
        }
    }

    float diffToRound()
    {
        float g = Mathf.Abs(moved.x - Mathf.Round(moved.x));
        float h = Mathf.Abs(moved.y - Mathf.Round(moved.y));

        return g+h;
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
