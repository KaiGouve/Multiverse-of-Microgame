using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarManager : MonoBehaviour
{
    public Vector2Int direction;

    public Vector2Int[] car0 =
    {
        new Vector2Int(0,0),new Vector2Int(1,0)
    };
    public Vector2Int[] car1 =
    {
        new Vector2Int(0,0),new Vector2Int(0,1)
    };
    public Vector2Int[] car2 =
    {
        new Vector2Int(0,0),new Vector2Int(1,0), new Vector2Int(2,0)
    };

    public Vector2Int[][] carLibrary;

    public Vector2Int[] startPos =
    {
        new Vector2Int(0,2),new Vector2Int(3,2), new Vector2Int(1,0)
    };

    Dictionary<Vector2Int, CarScript> Cars = new Dictionary<Vector2Int, CarScript>();

    void Start()
    {
        carLibrary[0] = car0;
        carLibrary[1] = car1;
        carLibrary[2] = car2;
    }


    


}
