using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Randomizer : MonoBehaviour
{
    public List<RandomItems> randomItems;

    [System.Serializable]
    public class RandomItems
    {
        public GameObject item;
        public int numberOfItems;
    }

    void Start()
    {

    }

    public void SpawnRandomItems()
    {
        var cItem = randomItems[Random.Range(0, randomItems.Count)];

        if (randomItems != null)
        {
            if (cItem.numberOfItems > 1)
            {
                for (int i = 0; i < cItem.numberOfItems; i++)
                {
                    var spawnPosition = new Vector3(transform.position.x + Random.Range(-1.5f, 1.5f), transform.position.y, transform.position.z + Random.Range(-1.5f, 1.5f));
                    Instantiate(cItem.item, spawnPosition, transform.rotation);
                }
            }
            else if (cItem.numberOfItems <= 1)
            {
                Instantiate(cItem.item, transform.position, transform.rotation);
            }
        }
    }
}
