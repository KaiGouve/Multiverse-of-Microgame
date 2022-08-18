using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class World : MonoBehaviour
{
    private List<WorldsCollection> worldsInit;
    public List<WorldsCollection> worlds;
    public bool next;
    [SerializeField, ReadOnly] List<string> lWorld;


    void Start()
    {
        worldsInit = worlds;
        DontDestroyOnLoad(gameObject);

        List<string> listWorld = new List<string>();
        //List<string> listMicroGame = new List<string>();

        foreach (WorldsCollection item in worlds)
        {
            listWorld.Add(item.worldName);

            string[] games = item.allMinigames.ToArray();
            item.poolMinigames = games.ToList();
        }

        lWorld = listWorld.ToList();
    }

    public void NextGame()
    {
        if (lWorld.Count == 0)
        {
            //all worlds has been played
            //show win screen or somethin
            Debug.Log("All games completed");
            return;
        }

        int iWorld = lWorld.Count - 1;
        int iPool = Random.Range(0, worlds[iWorld].poolMinigames.Count);
        
        

        updateMusic(iWorld);
        


        if ((worlds[iWorld].poolMinigames.Count) > 1)
        {
            //load that scene by name
            SceneManager.LoadScene(worlds[iWorld].poolMinigames[iPool]);

            worlds[iWorld].poolMinigames.RemoveAt(iPool);
        }
        else
        {
            //load that scene by name
            SceneManager.LoadScene(worlds[iWorld].poolMinigames[iPool]);

            worlds[iWorld].poolMinigames.RemoveAt(iPool);
            lWorld.RemoveAt(iWorld);
        }
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
    void updateMusic(int world)
    {
        Debug.Log(4 - world + "WORLD");
        GetComponent<MusicManager>().ChangeWorldMusic(4 - world);
        GetComponent<MouseScript>().changeCursor(4 - world);
    }
    public void ExitGame()
    {
        Application.Quit();
    }

    public void ResetWorld()
    {
        Destroy(this);
    }

    public void StartFromWorld(int n)
    {
        
        int iWorld = lWorld.Count - n;
        for (int i = 0; i < n; i++)
        {
            lWorld.RemoveAt(iWorld);
        }
        
    }
    public void ReturnToMenu()
    {
        worlds = worldsInit;
        SceneManager.LoadScene("EmptyScene");
        Time.timeScale = 1;
    }
}

[System.Serializable]
public class WorldsCollection
{
    public string worldName; // worlds name
    public List<string> allMinigames; // populate with the scene's names in inspector
    [SerializeField, ReadOnly] public List<string> poolMinigames;
}


