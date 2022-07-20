using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarManager : MonoBehaviour
{
    [SerializeField] GameObject[] Cars;


    Vector3[] Cars0 = new Vector3[]
    {
        new Vector3(0.5f,2),new Vector3(-1,1),new Vector3(-2,2),new Vector3(-3,3),new Vector3(-4,4)
    };
    Vector3[] Cars1 =
    {
        new Vector3(),new Vector3(),new Vector3(),new Vector3(),new Vector3()
    };
    Vector3[] Cars2 =
    {
        new Vector3(),new Vector3(),new Vector3(),new Vector3(),new Vector3()
    };
    Vector3[] Cars3 =
    {
        new Vector3(),new Vector3(),new Vector3(),new Vector3(),new Vector3()
    };
    Vector3[] Cars4 =
    {
        new Vector3(),new Vector3(),new Vector3(),new Vector3(),new Vector3()
    };


    public Vector3[][] carLibrary = new Vector3[5][];



    void Start()
    {
        carLibrary[0] = Cars0;
        carLibrary[1] = Cars1;
        carLibrary[2] = Cars2;
        carLibrary[3] = Cars3;
        carLibrary[4] = Cars4;
        generateGame(0);
    }
    public void generateGame(int ArrNum)
    {
        for (int i = 0; i < Cars.Length; i++)
        {
            if (carLibrary[ArrNum][i].x >= 0)
            {
                Instantiate(Cars[i], FTR(carLibrary[ArrNum][i]), Quaternion.identity);
            }
                                                                                                
        }

    }
    Vector3 FTR(Vector3 input)
    {
        return input - new Vector3(2f,2f,3f);
    }





}
