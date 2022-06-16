using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public KeyCode accept;
    public KeyCode back;

    public KeyCode leftClick;
    public KeyCode rightClick;
    public KeyCode MidClick;

    public KeyCode up;
    public KeyCode down;
    public KeyCode left;
    public KeyCode right;

    public KeyCode spaceBar;

    public KeyCode Accept() { return accept; }
    public KeyCode Back() { return back; }

}
