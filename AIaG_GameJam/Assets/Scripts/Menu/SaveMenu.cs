using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SaveMenu : MonoBehaviour
{
    [SerializeField] List<TextMeshProUGUI> saveButtonTexts;

    private void Start()
    {
        for(int i = 0; i < saveButtonTexts.Count; i++)
        {
            bool exists = false;
            string path = SaveSystem.SavePath(i, out exists);
            saveButtonTexts[i].text = exists ? "Save " + i : "New Save";
        }
    }

    public void StartGameButton(int indexSave)
    {
        SaveSystem.saveNumber = indexSave;
        SceneManager.LoadScene("Game");
        // dans la scène de jeu, on appellera la fct load du savesystem au tout début
    }
}
