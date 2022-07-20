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

    // Start is called before the first frame update
    void Start()
    {
        //Time.timeScale = 1;
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
        // Return to Scene
        if (loadToScene == null)
        {
            if (Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene(loadToScene);
            }
        }
    }
}
