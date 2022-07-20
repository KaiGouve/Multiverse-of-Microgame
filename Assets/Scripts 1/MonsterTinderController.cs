using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MonsterTinderController : MonoBehaviour
{
    public Image identity;
    public Image conditionIdentity;
    public Image interested;
    public Image conditionInterested;

    public Sprite[] genders;
    // Start is called before the first frame update
    void Start()
    {
        identity.sprite = genders[Random.Range(0, 3)];
        conditionIdentity.sprite = genders[Random.Range(0, 3)];
        interested.sprite = genders[Random.Range(0, 3)];
        conditionInterested.sprite = genders[Random.Range(0, 3)];
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
