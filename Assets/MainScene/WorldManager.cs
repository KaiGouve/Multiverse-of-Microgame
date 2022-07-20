using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldManager : MonoBehaviour
{
    public List<string> allMinigames; // populate with the scene's names in inspector
    List<string> poolMinigames;

    public bool next;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        string[] games = allMinigames.ToArray();
        poolMinigames = games.ToList();
    }

    public void NextGame()
    {
        if (poolMinigames.Count == 0)
        {
            //all minigames played
            //show win screen or somethin
            Debug.Log("All games completed");
            return;
        }

        //get a random minigame
        int i = Random.Range(0, poolMinigames.Count - 1);
        //load that scene by name
        SceneManager.LoadScene(poolMinigames[i]);
        poolMinigames.RemoveAt(i);
    }

    // Update is called once per frame
    void Update()
    {
        if (next)
        {
            next = false;
            NextGame();
            Time.timeScale = 1;
        }
    }
}
