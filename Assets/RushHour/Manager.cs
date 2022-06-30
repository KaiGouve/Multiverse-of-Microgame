using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    [SerializeField] private GameObject Tile;
    [SerializeField] private GameObject carPart;
    private Vector2 startPosition = new Vector2(-2f,-2f);
    [SerializeField] private Vector2Int startclick;
    [SerializeField] private Vector2Int diff;

    [SerializeField] private Vector2Int[] car0 = {new Vector2Int(1,0), new Vector2Int(0,2), new Vector2Int(1,2) };

    Vector2Int[][] cars = new Vector2Int[1][];

    GameObject[,] positions = new GameObject[5,5];

    // Start is called before the first frame update
    void Start()
    {
        cars[0] = car0;

        GenerateTiles();
        GenerateCars();
    }

    void GenerateTiles()
    {
        for(int x = 0; x<5; x++)
        {
            for (int y = 0; y < 5; y++)
            {
                Vector2 pos = new Vector2(x, y);
                GenerateTile(pos);
            }
        }
    }
    void GenerateCars()
    {
        foreach(Vector2Int[] car in cars)
        {
            for( int i = 1; i < car.Length; i++)
            {
                Vector2 Real = FtR(new Vector2(car[i].x, car[i].y));


                GameObject carPrefab = Instantiate(carPart, new Vector3(Real.x, Real.y, -1), Quaternion.identity);
                positions[car[i].x, car[i].y] = carPrefab;
            }
        }
    }
    Vector2 FtR(Vector2 a)
    {
        return a - new Vector2(2,2);
    }

    void GenerateTile(Vector2 position)
    {
        GameObject tilePrefab = Instantiate(Tile, FtR(position), Quaternion.identity);

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            startclick = mP();
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            StartDrag(startclick, mP());
        }
        /*
        if (Input.GetKey(KeyCode.Mouse0))
        {
            diff = mP()-startclick;
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {

            CheckMoveCar(Vector2Int.RoundToInt(startclick), Vector2Int.RoundToInt(diff));
        }*/
    }
    Vector2Int mP()
    {
        return Vector2Int.CeilToInt(Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(1.5f, 1.5f));
    }

    void StartDrag(Vector2Int startP,Vector2Int endP)
    {
        Debug.Log(Vector2Int.CeilToInt(startP));
        //Check for a car at start
        if (!checkPos(Vector2Int.CeilToInt(startP))){ return;}


        // get car num & difference
        int carNum = CarNumAtPos(Vector2Int.CeilToInt(startP));
        Vector2Int[] car = cars[carNum];
        Vector2Int Diff = endP - startP;
        Diff *= car[0];
        Debug.LogError("DIFF + " + Diff);

        // get the positions of all the parts of the car
        //Check the positions between here and there for all pieces

        Vector2Int[] tempCar = car;
        for (int i = 1; i< tempCar.Length; i++)
        {
            tempCar[i] += Diff;
        }

        if (EmptyEveryPos(carNum,Diff, car))
        {
            Debug.LogError("Every pos clear");
            for (int i =1;i<car.Length;i++)
            {
                positions[tempCar[i].x, tempCar[i].y] = positions[car[i].x, car[i].y];

                positions[car[i].x, car[i].y].transform.position += new Vector3(Diff.x, Diff.y);

                positions[car[i].x, car[i].y] = null;

            }


            cars[carNum] = tempCar;
        }
        
    }
    bool EmptyEveryPos(int carNum, Vector2Int Diff,Vector2Int[] car)
    {
        for (int pieceNum = 1; pieceNum < cars[carNum].Length; pieceNum++)
        {
            for (int move = 1; move < Diff.magnitude; move++)
            {
                if (checkPos(car[pieceNum]) && CarNumAtPos(car[pieceNum]) != carNum)
                {
                    Debug.LogError("clear at ");
                }
                else
                {
                    return false;
                }
            }
        }
        return true;
    }

    bool checkPos(Vector2Int position)
    {
        for (int carnum = 0; carnum < cars.Length; carnum++)
        {
            List<Vector2Int> carList = new List<Vector2Int>(cars[carnum]);
            carList.RemoveAt(0);
            if (carList.Contains(position))
            {
                return true;
            }
        }
        return false;
    }
    int CarNumAtPos(Vector2Int position)
    {
        Debug.Log($"Checking position {position}");
        for (int carnum = 0; carnum < cars.Length; carnum++)
        {
            List<Vector2Int> carList = new List<Vector2Int>(cars[carnum]);
            carList.RemoveAt(0);
            Debug.Log($" carnum {carnum} length {cars.Length} pos {position}");
            //Debug.LogWarning($"{carList[0]} , {carList[1]} , {carList[2]}");
            if (carList.Contains(position))
            {
                return carnum;
            }
        }
        return -1;
    }

    /*
        void CheckMoveCar(Vector2Int start,Vector2Int amount)
        {
            Debug.Log($"Checking move car [{start}] start by amount [{amount}]");
            int carNum = CheckPos(start);
            if (carNum == -1)
            {
                return;
            }
            amount *= cars[carNum][0];
            Debug.Log("AMOUNT " + amount);
            Debug.LogError("HERE MOVING1 " + diff);
            int moves = (int)amount.magnitude;
            Vector2 axis = new Vector2(amount.x,amount.y).normalized;
            Debug.LogError("HERE MOVING1 " + diff);
            if (CheckAllPositions(start,axis,moves))
            {
                Debug.LogError("HERE MOVING2 " + diff);
                MoveCar(start, amount, carNum);
            }

        }
        bool CheckAllPositions(Vector2Int startpos,Vector2 aOM,int moves)
        {
            for(int i = 0; i<moves; i++)
            {
                if (CheckPos(startpos + Vector2Int.RoundToInt(aOM) * i) != -1)
                {
                    if (CheckPos(startpos) != CheckPos(startpos + Vector2Int.RoundToInt(aOM) * i))
                    {
                        return false;
                    }
                }

            }

            return true;
        }
        int CheckPos(Vector2Int position)
        {
            Debug.Log($"Checking position {position}");
            for (int carnum = 0; carnum < cars.Length; carnum++)
            {
                List<Vector2Int> carList = new List<Vector2Int>(cars[carnum]);
                Debug.Log($" carnum {carnum} length {cars.Length} pos {position}");
                Debug.LogWarning($"{carList[0]} , {carList[1]} , {carList[2]}");
                if (carList.Contains(position))
                {
                    return carnum;
                }
            }
            return -1;
        }

        void MoveCar(Vector2 startPos,Vector2 diff,int carNum)
        {
            Debug.LogError("HERE MOVING " + diff);
            Vector2Int[] temp = new Vector2Int[cars[carNum].Length];
            for(int i = 0; i < cars[carNum].Length; i++)
            {
                temp[i] = cars[carNum][i];
                if(i == 0)
                {
                    continue;
                }
                Debug.LogError($"{positions[cars[carNum][i].x, cars[carNum][i].y]} +  i: {i}");
                positions[cars[carNum][i].x, cars[carNum][i].y].transform.position += new Vector3(diff.x,diff.y);
                positions[cars[carNum][i].x + (int)diff.x, cars[carNum][i].y + (int)diff.y] = positions[cars[carNum][i].x, cars[carNum][i].y];
                positions[cars[carNum][i].x, cars[carNum][i].y] = null;
            }

            cars[carNum] = temp;
        }*/




    ///From start position, get car parts





    ///for each car parts check until end clear
    ///move parts

}
