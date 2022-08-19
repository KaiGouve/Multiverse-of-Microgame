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
    int matchChance;

    public Sprite[] genders;
    // Start is called before the first frame update
    void Start()
    {
        matchChance = Random.Range(0, 5);
        identity.sprite = genders[Random.Range(0, 3)];
        conditionIdentity.sprite = genders[Random.Range(0, 3)];
        interested.sprite = genders[Random.Range(0, 3)];
        conditionInterested.sprite = genders[Random.Range(0, 3)];
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwipeLeft() {
        if (conditionIdentity.sprite == identity.sprite && conditionInterested.sprite == interested.sprite) {
            Debug.Log("You lost a match!");
            // Lose State;
        } else {
            if (matchChance < 8) {
                conditionIdentity.sprite = genders[Random.Range(0, 3)];
                conditionInterested.sprite = genders[Random.Range(0, 3)];
                matchChance ++;
            } else {
                conditionIdentity.sprite = identity.sprite;
                conditionInterested.sprite = interested.sprite;
            }
        }
    }

    public void SwipeRight() {
        if (conditionIdentity.sprite == identity.sprite && conditionInterested.sprite == interested.sprite) {
            Debug.Log("You found a match!");
            // Win State;
        } else {
            Debug.Log("They're not interested!");
            // Lose State;
        }
    }
}
