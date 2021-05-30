using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseSystem : MonoBehaviour
{
    bool pause = false;
    [SerializeField] GameObject menu;

    [SerializeField] List<GameObject> activeByDefault;
    [SerializeField] List<GameObject> notActiveByDefault;

    private void Start()
    {
        CursorManager.DeactivateCursor();
    }

    public void OnPause(InputAction.CallbackContext ctx)
    {
        if (!ctx.performed)
        {
            return;
        }

        Pause();
    }

    public void Pause()
    {
        pause = !pause;
        Time.timeScale = pause ? 0 : 1;
        if (pause)
        {
            Debug.Log("oui");
            foreach (GameObject gO in activeByDefault)
            {
                gO.SetActive(true);
            }
            foreach (GameObject gO in notActiveByDefault)
            {
                gO.SetActive(false);
            }
            CursorManager.ActivateCursor();
        }
        else
        {
            CursorManager.DeactivateCursor();
        }
        menu.SetActive(pause);
    }
}
