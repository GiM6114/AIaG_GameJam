using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    public void ChangeScene(string scene)
    {
        SceneManager.LoadScene(scene);
        // dans la sc�ne de jeu, on appellera la fct load du savesystem au tout d�but
    }

    public void DeletePrefs()
    {

    }
}
