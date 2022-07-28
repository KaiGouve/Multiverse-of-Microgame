using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CAVCarManager : MonoBehaviour
{
    [SerializeField] GameObject[] Cars;
    public UnityEvent nextScene;


    Vector3[] Cars0 = new Vector3[]
    {
        new Vector3(0.5f,1),new Vector3(3,2),new Vector3(3,4),new Vector3(0,3.5f),new Vector3(3.5f,0)
    };
    Vector3[] Cars1 =
    {
        new Vector3(2.5f,4),new Vector3(4,3),new Vector3(3,1),new Vector3(1,0.5f),new Vector3(0.5f,3)
    };
    Vector3[] Cars2 =
    {
        new Vector3(1.5f,3),new Vector3(0,2),new Vector3(2,1),new Vector3(3,3.5f),new Vector3(2.5f,0)
    };


    public Vector3[][] carLibrary = new Vector3[3][];



    void Start()
    {
        carLibrary[0] = Cars0;
        carLibrary[1] = Cars1;
        carLibrary[2] = Cars2;
        generateGame(Random.Range(0,3));
    }
    public void generateGame(int ArrNum)
    {
        for (int i = 0; i < Cars.Length; i++)
        {
            if (carLibrary[ArrNum][i].x >= 0)
            {
                GameObject car = Instantiate(Cars[i], FTR(carLibrary[ArrNum][i]), Quaternion.identity);
                if (i == 0)
                {
                    Physics2D.IgnoreCollision(car.GetComponent<BoxCollider2D>(), GetComponent<PolygonCollider2D>());
                    car.GetComponent<CAVCarScript>().cM = this;
                }
            }
                                                                                                
        }

    }
    Vector3 FTR(Vector3 input)
    {
        return input - new Vector3(2f,2f,3f);
    }





}
