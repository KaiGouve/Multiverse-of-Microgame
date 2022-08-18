using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JTOver : MonoBehaviour
{
    public GameObject gameManager;

    public void Start()
    {
        Time.timeScale = 0.00001f;
        gameManager = GameObject.Find("WorldManager");
    }

    public void Update()
    {
        Debug.Log(Time.timeScale);

        //StartCoroutine(DestroyFirst());
    }

    public void StartAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void MainMenu()
    {
        Destroy(gameManager);
        SceneManager.LoadScene("MainScene");
        Time.timeScale = 1;
    }

    public void Destroy()
    {
        Destroy(gameManager);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
