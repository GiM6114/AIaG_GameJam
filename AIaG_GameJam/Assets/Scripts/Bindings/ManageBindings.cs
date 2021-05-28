using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public static class ManageBindings
{
    public static void Save(PlayerInput pI)
    {
        foreach (var actionMap in pI.actions.actionMaps)
        {
            foreach (var action in actionMap)
            {
                string name = actionMap.name + "/" + action.name;

                for (int i = 0; i < action.bindings.Count; i++)
                {
                    PlayerPrefs.SetString(name + i, action.bindings[i].effectivePath);
                }
            }
        }
    }

    public static void Load(PlayerInput pI)
    {
        foreach (var actionMap in pI.actions.actionMaps)
        {
            foreach (var action in actionMap)
            {
                string name = actionMap.name + "/" + action.name;

                for (int i = 0; i < action.bindings.Count; i++)
                {
                    string newBinding = PlayerPrefs.GetString(name + i, action.bindings[i].effectivePath);
                    action.ApplyBindingOverride(i, newBinding);
                    Debug.Log(action.bindings[i].effectivePath);
                }
            }
        }
    }
}
