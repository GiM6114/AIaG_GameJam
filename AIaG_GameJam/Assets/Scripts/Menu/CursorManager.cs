using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CursorManager
{
    public static void ActivateCursor()
    {
        Cursor.SetCursor(Resources.Load("Sprites/final_fantasy_cursor") as Texture2D, Vector2.zero, CursorMode.Auto);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public static void DeactivateCursor()
    {
        Cursor.visible = false;
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        Cursor.lockState = CursorLockMode.Locked;
    }
}
