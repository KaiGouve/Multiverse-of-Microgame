using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverCanvas;
    public string loadToScene;

    public UnityEvent gameOver;

    World world;

    bool callOnce = false;

    // Start is called before the first frame update
    void Start()
    {
 
    }

    void Update()
    {
        if (callOnce == true)
        {

            if (Input.GetMouseButtonDown(0))
            {
                //Debug.Log("GameObject" + name + " loadToScene " + loadToScene);
                SceneManager.LoadScene(loadToScene);
                Time.timeScale = 1;
                callOnce = false;
            }
        }
    }

    public void GameOverPanel()
    {
        //gameOverCanvas.SetActive(true);
        Instantiate(gameOverCanvas, new Vector3(0, 0, 0), Quaternion.identity);
        gameOver.Invoke();
        Time.timeScale = 0;
    }

    public void ReturntoScene()
    {
        callOnce = true;
        //Debug.Log("callOnce " + callOnce);
    }

    public void NextGame()
    {
        world = (World)GameObject.Find("WorldManager").GetComponent(typeof(World));

        if (world != null)
        {
            world.NextGame();
            Time.timeScale = 1;
        }
    }
}
