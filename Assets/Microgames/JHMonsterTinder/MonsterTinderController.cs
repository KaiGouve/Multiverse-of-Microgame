using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class MonsterTinderController : MonoBehaviour
{
    public Image identity;
    public Image conditionIdentity;
    public Image interested;
    public Image conditionInterested;
    int matchChance;

    public Sprite[] genders;

    [SerializeField] Sprite[] matches;
    [SerializeField] Image match;

    [SerializeField] UnityEvent winState;
    [SerializeField] UnityEvent lossState;
    [SerializeField] UnityEvent interest;

    int myInterest;
    // Start is called before the first frame update
    void Start()
    {
        int identitynum = Random.Range(0, 3);
        myInterest = Random.Range(0, 3);
        match.sprite = matches[identitynum];
        matchChance = Random.Range(0, 5);
        identity.sprite = genders[Random.Range(0, 3)];
        conditionIdentity.sprite = genders[myInterest];
        interested.sprite = genders[Random.Range(0, 3)];
        conditionInterested.sprite = genders[identitynum];

    }



    public void SwipeLeft() {
        if (conditionIdentity.sprite == identity.sprite && conditionInterested.sprite == interested.sprite) {
            Debug.Log("You lost a match!");
            // Lose State;
            lossState.Invoke();
        } else {
            if (matchChance < 8) {

                int identitynum = Random.Range(0,3);
                match.sprite = matches[identitynum];
                conditionIdentity.sprite = genders[Random.Range(0, 3)];
                conditionInterested.sprite = genders[identitynum];
                matchChance ++;
            } else {
                match.sprite = matches[myInterest];
                conditionIdentity.sprite = identity.sprite;
                conditionInterested.sprite = interested.sprite;
            }
        }
    }

    public void SwipeRight() {
        if (conditionIdentity.sprite == identity.sprite && conditionInterested.sprite == interested.sprite) {
            Debug.Log("You found a match!");
            // Win State;
            winState.Invoke();
        } else {
            Debug.Log("They're not interested!");
            // Lose State;
            interest.Invoke();
        }
    }
}
