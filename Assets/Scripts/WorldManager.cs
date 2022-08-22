using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour
{
    public List<Worlds> worlds;
}

[Serializable]
public class Worlds
{
    [SerializeField] public bool finished;
    [SerializeField] public List<string> microgame;
}
