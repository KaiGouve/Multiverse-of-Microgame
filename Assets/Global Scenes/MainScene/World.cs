using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class World : MonoBehaviour
{
    public List<WorldsCollection> worlds;
    public bool next;
    [SerializeField, ReadOnly] List<string> lWorld;

    [SerializeField, ReadOnly] List<GameObject> wTransfer;

    [SerializeField, ReadOnly] bool callOnce = false;

    void Start()
    {
        DontDestroyOnLoad(gameObject);

        List<string> listWorld = new List<string>();
        //List<string> listMicroGame = new List<string>();

        List<GameObject> listTransfer = new List<GameObject>();

        foreach (WorldsCollection item in worlds)
        {
            listWorld.Add(item.worldName);

            string[] games = item.allMinigames.ToArray();
            item.poolMinigames = games.ToList();

            listTransfer.Add(item.worldTransfer);
        }

        lWorld = listWorld.ToList();

        wTransfer = listTransfer.ToList();
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
        
        //Cody Debugging
        //Debug.Log(worlds[worlds[iWorld].poolMinigames.Count]);
        //Debug.LogWarning($" ipool {iPool}. poolminigames.count {worlds[iWorld].poolMinigames.Count} and iworld {iWorld}");

        if ((worlds[iWorld].poolMinigames.Count) > 1)
        {
            //load that scene by name
            SceneManager.LoadScene(worlds[iWorld].poolMinigames[iPool]);

            worlds[iWorld].poolMinigames.RemoveAt(iPool);
        }
        else
        {
            int iTransfer = wTransfer.Count - 1;

            if (worlds[iTransfer].worldTransfer != null)
            {
                if (callOnce == true)
                {
                    NextGameWorld(iWorld, iPool);
                    callOnce = false;
                }
                else
                {
                    Instantiate(worlds[iTransfer].worldTransfer, transform.position, transform.rotation);
                    callOnce = true;
                }
            }
            else
            {
                NextGameWorld(iWorld, iPool);
            }
        }
    }

    void NextGameWorld(int iWorld, int iPool)
    {
        //load that scene by name
        SceneManager.LoadScene(worlds[iWorld].poolMinigames[iPool]);

        worlds[iWorld].poolMinigames.RemoveAt(iPool);
        lWorld.RemoveAt(iWorld);
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

[System.Serializable]
public class WorldsCollection
{
    public string worldName; // worlds name
    public GameObject worldTransfer;
    public List<string> allMinigames; // populate with the scene's names in inspector
    [SerializeField, ReadOnly] public List<string> poolMinigames;
}
