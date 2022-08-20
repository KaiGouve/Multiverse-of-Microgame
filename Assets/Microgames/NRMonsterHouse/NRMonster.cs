using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NRMonster : MonoBehaviour
{
    [SerializeField] Transform[] Positions;
    int monsterMovement = 1;
    float i = 0;
    float speed = 1;

    SpriteRenderer sR;
    // Start is called before the first frame update
    void Start()
    {
        sR = GetComponent<SpriteRenderer>();
        monsterMovement = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (monsterMovement >= Positions.Length)
        {
            monsterMovement = 1;
        }
        sR.flipX = Positions[monsterMovement].position.x < transform.position.x ? true : false;
        i += Time.deltaTime * speed;
        if (i > 1)
        {
            i = 1;
        }
        
        transform.position=Vector3.Lerp(Positions[monsterMovement - 1].position, Positions[monsterMovement].position, i);
        if (i == 1)
        {
            i = 0;
            monsterMovement += 1;
            
        }
    }
}
