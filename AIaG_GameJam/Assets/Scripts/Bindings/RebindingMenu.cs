using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.UI;

public class RebindingMenu : MonoBehaviour
{
    [SerializeField] PlayerInput pI = null;
    [Space]
    [SerializeField] List<InputActionReference> action = null;
    [SerializeField] int index;
    [SerializeField] bool gamepad = false;
    [Space]
    [SerializeField] TMP_Text bindingDisplayNameText = null;
    [SerializeField] GameObject startRebindObject = null;
    [SerializeField] GameObject waitingForInputObject = null;

    private InputActionRebindingExtensions.RebindingOperation rebindingOperation;
    Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
    }

    private void Start()
    {
        UpdateUI();
    }

    public void StartRebinding()
    {
        button.animator.SetTrigger("Highlighted");

        startRebindObject.SetActive(false);
        waitingForInputObject.SetActive(true);

        pI.currentActionMap.Disable();

        rebindingOperation = action[0].action.PerformInteractiveRebinding(index);
        if (gamepad)
        {
            rebindingOperation.WithControlsExcluding("<Keyboard>");
            rebindingOperation.WithControlsExcluding("<Mouse>");
        }
        else
        {
            rebindingOperation.WithControlsExcluding("<Gamepad>");
        }
        rebindingOperation.OnMatchWaitForAnother(0.1f)
            .OnComplete(operation => RebindComplete())
            .OnCancel(operation => RebindComplete())
            .Start();
    }

    private void RebindComplete()
    {
        UpdateUI();
        rebindingOperation.Dispose();

        // Binding des actions des autres map liées 
        for (int i = 1; i < action.Count; i++)
        {
            action[i].action.ApplyBindingOverride(index, action[0].action.bindings[index].effectivePath);
        }

        startRebindObject.SetActive(true);
        waitingForInputObject.SetActive(false);

        pI.currentActionMap.Enable();

        ManageBindings.Save(pI);
    }

    private void UpdateUI()
    {
        bindingDisplayNameText.text = InputControlPath.ToHumanReadableString(action[0].action.bindings[index].effectivePath, InputControlPath.HumanReadableStringOptions.OmitDevice);
        button.animator.SetTrigger("Disabled");
    }
}
