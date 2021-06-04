using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SignMenu : MonoBehaviour
{
    public Image[] signs;

    private void OnValidate()
    {
        int i = 0;
        foreach(Image image in signs)
        {
            image.sprite = Resources.Load<Sprite>("Sprites/Signs/" + i.ToString());
            image.color = Color.black;
            i++;
        }
    }

    public void ActivateSign(int index)
    {
        signs[index].color = Color.white;
    }
}
