using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CAVManager : MonoBehaviour
{
    [SerializeField] private GameObject Tile;


    void Start()
    {
        GenerateTiles();
        GenerateCars();
    }

    void GenerateTiles()
    {
        for(int x = 0; x<5; x++)
        {
            for (int y = 0; y < 5; y++)
            {
                Vector2 pos = new Vector2(FTR(x), FTR(y));
                Instantiate(Tile, pos, Quaternion.identity, this.transform);
            }
        }
    }
    float FTR(float input)
    {
        return input-2f;
    }

    void GenerateCars()
    {

    }
}
