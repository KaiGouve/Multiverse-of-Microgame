using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarScript : MonoBehaviour
{
    [SerializeField] Vector2 Direction;
    [SerializeField] Vector3 centre;
    [SerializeField] Vector3 diff;
    Vector3 pos;
    private Rigidbody2D rb;
    Vector3 offset = Vector2.zero;

    private void OnMouseDrag()
    {
        
    }
    private void Update()
    {
        pos = transform.position + centre;


        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            offset = Diff();
        }
        if (Input.GetKey(KeyCode.Mouse0))
        {
            diff = Direction.normalized * (Diff()-offset);
            rb.velocity = diff * Time.deltaTime*1000;
        }
        if (!Input.GetKey(KeyCode.Mouse0)&& diffToRound(transform.position)<=0.02f&& rb.velocity.magnitude!=0)
        {
            if(diffToRound(transform.position) <= 0.02f)
            {
                rb.velocity = Vector2.zero;
               // transform.position = new Vector3(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y), -3);
            }
            
        }

        
    }
    float diffToRound(Vector3 h)
    {
        Vector3 unitPos = h;

        


        Debug.Log(Mathf.Abs((h.x - Mathf.Round(h.x)) * Direction.x + (h.y - Mathf.Round(h.y))) * Direction.y);
        Debug.LogError($"{h.x} + {h.y}");
        return Mathf.Abs(Mathf.Abs((h.x - Mathf.Round(h.x)) * Direction.x + (h.y - Mathf.Round(h.y))) * Direction.y);
        

    }
    Vector3 Diff()
    {
        return mousePos() - transform.position;
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
