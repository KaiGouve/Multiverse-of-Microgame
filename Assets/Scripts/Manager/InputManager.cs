using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public KeyCode accept = KeyCode.Z;
    public KeyCode back = KeyCode.X;

    public KeyCode leftClick = KeyCode.Mouse0;
    public KeyCode rightClick = KeyCode.Mouse2;
    public KeyCode midClick = KeyCode.Mouse1;

    public KeyCode up = KeyCode.UpArrow;
    public KeyCode down = KeyCode.DownArrow;
    public KeyCode left = KeyCode.LeftArrow;
    public KeyCode right = KeyCode.RightArrow;

    public KeyCode w = KeyCode.W;
    public KeyCode s = KeyCode.A;
    public KeyCode a = KeyCode.S;
    public KeyCode d = KeyCode.D;

    public KeyCode spaceBar = KeyCode.Space;

    public KeyCode Accept { get { return accept; } }
    public KeyCode Back { get { return back; } }

    public KeyCode LeftClick { get { return leftClick; } }
    public KeyCode RightClick { get { return rightClick; } }
    public KeyCode MidClick { get { return midClick; } }

    public KeyCode W { get { return w; } }
    public KeyCode A { get { return a; } }
    public KeyCode S { get { return s; } }
    public KeyCode D { get { return d; } }

    public KeyCode Up { get { return up; } }
    public KeyCode Down { get { return down; } }
    public KeyCode Left { get { return left; } }
    public KeyCode Right { get { return right; } }

    public KeyCode SpaceBar { get { return spaceBar; } }
}
