using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CAVGunScript : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject enemy;

    float cooldownG = 0.3f;
    float timerG = 0;
    float cooldownS = 1f;
    float timerS = 0;
    float speed = 0.8f;

    int spawnAmount = 30;
    int amountLeft = 30;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(Mathf.Clamp(Mathf.Lerp(transform.position.x, transform.position.x + Input.GetAxisRaw("Horizontal") * speed, 0.05f), -8.15f, 8.15f), -4.3f) ;
        if(Input.GetKey(KeyCode.Space)&& timerG <= 0)
        {
            Instantiate(bullet, transform.position,Quaternion.identity);
            timerG = cooldownG;
        }
        timerG -= Time.deltaTime;

        if (spawnAmount > 0 && timerS <= 0)
        {
            Instantiate(enemy, new Vector2(Mathf.Sin(Time.time)*6,6), Quaternion.identity);
            timerS = cooldownS;
            spawnAmount--;
        }
        timerS -= Time.deltaTime;
    }
    public void dead()
    {
        amountLeft--;
        if (amountLeft == 0)
        {
            //win
            Debug.Log("WON");
        }
    }
}
