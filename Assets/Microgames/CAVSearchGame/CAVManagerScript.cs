using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class CAVManagerScript : MonoBehaviour
{
    [SerializeField] GameObject canvas;
    [SerializeField] GameObject flashlight;
    [SerializeField] Sprite[] objectSprites;
    [SerializeField] GameObject[] SpriteSpawners;
    [SerializeField] public UnityEvent nextScene;
    [SerializeField] public UnityEvent fail;
    [SerializeField] GameObject timer;

    private void Start()
    {
        int rand = Random.Range(0, objectSprites.Length);
        for (int i = 0; i < SpriteSpawners.Length; i++)
        {
            int j = i - rand;
            if (j < 0)
                j += SpriteSpawners.Length;
            SpriteSpawners[i].GetComponent<SpriteRenderer>().sprite = objectSprites[j];
            SpriteSpawners[i].transform.position += new Vector3(Random.Range(-3, 3), Random.Range(-3, 3));
            SpriteSpawners[i].transform.position = new Vector2(Mathf.Clamp(SpriteSpawners[i].transform.position.x, -7.8f, 7.8f), Mathf.Clamp(SpriteSpawners[i].transform.position.y, -3.93f, 3.93f));
            if (j == 0)
            {
                SpriteSpawners[i].GetComponent<CAVButtonScript>().real = true;
            }
        }
        StartCoroutine(startGame());
    }

    IEnumerator startGame()
    {
        yield return new WaitForSeconds(4f);
        canvas.SetActive(false);
        flashlight.SetActive(true);
        timer.SetActive(true);
    }
}
