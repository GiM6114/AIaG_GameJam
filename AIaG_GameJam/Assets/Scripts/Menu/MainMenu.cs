using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public void Awake()
    {
        CursorManager.ActivateCursor();
    }

    public void QuitButton()
    {
        Application.Quit();
        Debug.Log("Game Closed");
    }
}
