// GENERATED AUTOMATICALLY FROM 'Assets/Input/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""fb8be6a2-cb70-42a4-877a-a100a74b9818"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""d533a197-a494-4430-9dc5-d5347e19beaa"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Escape"",
                    ""type"": ""Button"",
                    ""id"": ""3be869a4-a347-4c03-a319-92d034a1792b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""b4638e21-bc18-4c79-aa5f-6e34e0bd751d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Drop"",
                    ""type"": ""Button"",
                    ""id"": ""7ab56143-5c1d-4b4e-965c-59ae902dba6c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""MoveZQSD"",
                    ""id"": ""3e906624-cffd-4597-8ae4-8ca98c9e2231"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""40e4a8d4-50aa-4af6-a23e-d33be1b775fa"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""d61dbcba-11ff-4aa2-ab1b-def29d389e78"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""cd7088c0-f894-4d36-a698-b9a3e42f3520"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""cda186aa-a2a9-48b5-b19b-d0b93cdf7c8e"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""6b77e478-2206-4f0e-864e-e62164854cd8"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Escape"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""20cf0995-6fe4-401b-8551-86ac1af536f8"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""90aab092-5c72-4f59-a1d2-ae7a8052828b"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Drop"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Stop"",
            ""id"": ""f5e95399-1921-44e5-8a16-6bcc2e1c2232"",
            ""actions"": [
                {
                    ""name"": ""Nothing"",
                    ""type"": ""Button"",
                    ""id"": ""3b4c43ee-f0a6-46ec-a7ea-6e72a77680f6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""89d90e1c-73e4-4c93-9fe0-3ddfda23567f"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Nothing"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Gameplay
        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
        m_Gameplay_Move = m_Gameplay.FindAction("Move", throwIfNotFound: true);
        m_Gameplay_Escape = m_Gameplay.FindAction("Escape", throwIfNotFound: true);
        m_Gameplay_Interact = m_Gameplay.FindAction("Interact", throwIfNotFound: true);
        m_Gameplay_Drop = m_Gameplay.FindAction("Drop", throwIfNotFound: true);
        // Stop
        m_Stop = asset.FindActionMap("Stop", throwIfNotFound: true);
        m_Stop_Nothing = m_Stop.FindAction("Nothing", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Gameplay
    private readonly InputActionMap m_Gameplay;
    private IGameplayActions m_GameplayActionsCallbackInterface;
    private readonly InputAction m_Gameplay_Move;
    private readonly InputAction m_Gameplay_Escape;
    private readonly InputAction m_Gameplay_Interact;
    private readonly InputAction m_Gameplay_Drop;
    public struct GameplayActions
    {
        private @PlayerControls m_Wrapper;
        public GameplayActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Gameplay_Move;
        public InputAction @Escape => m_Wrapper.m_Gameplay_Escape;
        public InputAction @Interact => m_Wrapper.m_Gameplay_Interact;
        public InputAction @Drop => m_Wrapper.m_Gameplay_Drop;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                @Escape.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnEscape;
                @Escape.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnEscape;
                @Escape.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnEscape;
                @Interact.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnInteract;
                @Drop.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDrop;
                @Drop.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDrop;
                @Drop.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDrop;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Escape.started += instance.OnEscape;
                @Escape.performed += instance.OnEscape;
                @Escape.canceled += instance.OnEscape;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
                @Drop.started += instance.OnDrop;
                @Drop.performed += instance.OnDrop;
                @Drop.canceled += instance.OnDrop;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);

    // Stop
    private readonly InputActionMap m_Stop;
    private IStopActions m_StopActionsCallbackInterface;
    private readonly InputAction m_Stop_Nothing;
    public struct StopActions
    {
        private @PlayerControls m_Wrapper;
        public StopActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Nothing => m_Wrapper.m_Stop_Nothing;
        public InputActionMap Get() { return m_Wrapper.m_Stop; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(StopActions set) { return set.Get(); }
        public void SetCallbacks(IStopActions instance)
        {
            if (m_Wrapper.m_StopActionsCallbackInterface != null)
            {
                @Nothing.started -= m_Wrapper.m_StopActionsCallbackInterface.OnNothing;
                @Nothing.performed -= m_Wrapper.m_StopActionsCallbackInterface.OnNothing;
                @Nothing.canceled -= m_Wrapper.m_StopActionsCallbackInterface.OnNothing;
            }
            m_Wrapper.m_StopActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Nothing.started += instance.OnNothing;
                @Nothing.performed += instance.OnNothing;
                @Nothing.canceled += instance.OnNothing;
            }
        }
    }
    public StopActions @Stop => new StopActions(this);
    public interface IGameplayActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnEscape(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnDrop(InputAction.CallbackContext context);
    }
    public interface IStopActions
    {
        void OnNothing(InputAction.CallbackContext context);
    }
}
