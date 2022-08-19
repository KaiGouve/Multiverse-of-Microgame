using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour
{
    GameObject gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("WorldManager");
    }

    public void MainMenu()
    {
        Destroy(gameManager);
        SceneManager.LoadScene("MainScene");
        Time.timeScale = 1;
        Debug.Log("Main menu");
    }
}
