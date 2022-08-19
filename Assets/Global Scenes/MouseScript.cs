using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseScript : MonoBehaviour
{
    public int world;
    [SerializeField] Texture2D[] Textures;
    bool showCursor = true;
    private void OnEnable()
    {
        changeCursor(0);
    }
    public void toggleCursor(bool on)
    {
        showCursor = on;
        changeCursor(world);
    }
    private void Update()
    {
        Cursor.visible = showCursor;
    }
    public void changeCursor(int newWorld)
    {
        world = newWorld;
        Cursor.visible = showCursor;
        Cursor.SetCursor(Textures[newWorld], new Vector2(0.295f,0.2f),CursorMode.Auto);
        
    }
}
