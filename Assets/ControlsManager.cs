// GENERATED AUTOMATICALLY FROM 'Assets/ControlsManager.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @ControlsManager : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @ControlsManager()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""ControlsManager"",
    ""maps"": [
        {
            ""name"": ""Controls"",
            ""id"": ""3f6f87f9-1276-4f8c-bd27-55775cae1bec"",
            ""actions"": [
                {
                    ""name"": ""MoveAWEF"",
                    ""type"": ""Button"",
                    ""id"": ""380bbe1e-0ae0-4311-afb9-a87bea55fb3e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MoveKeypad"",
                    ""type"": ""Button"",
                    ""id"": ""5710700b-91d6-4f31-a75e-4f3c49a15d14"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MoveWASD"",
                    ""type"": ""Button"",
                    ""id"": ""b232e45f-8c7d-4f87-9875-e20827a3d892"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Grab"",
                    ""type"": ""Button"",
                    ""id"": ""9ddfee71-5a4a-49b2-8bc7-18bb724ff700"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RotateCamera"",
                    ""type"": ""Button"",
                    ""id"": ""0ef2ff28-97ba-4d57-9d95-782a8a9d768a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PauseMenu"",
                    ""type"": ""Button"",
                    ""id"": ""2715dfb5-1e63-4c9d-953b-b3fedc767657"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Undo"",
                    ""type"": ""Button"",
                    ""id"": ""6a91f703-0973-4e70-8fc3-5b0820560169"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""AWEF"",
                    ""id"": ""afb5d5c4-9c99-4bde-9dde-4f7b676eb0a8"",
                    ""path"": ""2DVector(mode=1)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveAWEF"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""7caeaf44-9e67-4d49-9eb9-8e66975bb1fb"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveAWEF"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""3b53e446-6991-4e10-9136-a3d0ba1da36c"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveAWEF"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""aa435cf8-f241-4e0b-9e8e-e3d48f90b31f"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveAWEF"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""5246b026-6e29-49c2-99e8-d55cc50c9bf7"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveAWEF"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""ArrowButtons"",
                    ""id"": ""321a0dbe-fb10-4405-a5f3-51fb822d9ec2"",
                    ""path"": ""2DVector(mode=1)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveAWEF"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""2fca598b-8f77-435a-9833-ed03246bfeca"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveAWEF"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""29ccae67-abd8-4394-8ae1-d4ccc3d26d1d"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveAWEF"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""1d283d34-886d-4b7d-9d4d-402068fc699d"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveAWEF"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""e5b2230a-c1e0-4936-9802-a3702070766b"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveAWEF"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""c46899fc-4e57-4258-91fb-ef6932880409"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Grab"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""mouseClick"",
                    ""id"": ""0b67b4e0-937a-4253-879f-7dc067fd1436"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateCamera"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""d6d967fa-7027-42fb-89e4-edb8cd7c0033"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateCamera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""622dd889-df29-402e-b0fc-ff69ba27ae1a"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateCamera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""0f5a2a4b-51c9-47ac-92ec-bf6220246e43"",
                    ""path"": ""<Keyboard>/m"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PauseMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9698674e-37ae-4b05-90c9-56642adef168"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PauseMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a2cafe79-fab6-493a-ab0d-cd6c2e4b6af8"",
                    ""path"": ""<Keyboard>/p"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PauseMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""545924be-cfa2-47d1-a54b-b66b0ffbc38b"",
                    ""path"": ""<Keyboard>/u"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Undo"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Keypad"",
                    ""id"": ""e55cb777-6cd7-46c7-b036-a914ff363b42"",
                    ""path"": ""2DVector(mode=1)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveKeypad"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""d6fecb68-b652-47aa-a807-467b1617ff66"",
                    ""path"": ""<Keyboard>/numpad9"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveKeypad"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""efce444e-ae37-4fce-be56-d97b25c4ab07"",
                    ""path"": ""<Keyboard>/numpad1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveKeypad"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""3f85bd19-099f-4476-b0d8-e2027c20597b"",
                    ""path"": ""<Keyboard>/numpad7"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveKeypad"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""ae770f9e-1c53-4d13-b589-959db0171631"",
                    ""path"": ""<Keyboard>/numpad3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveKeypad"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""ArrowButtons"",
                    ""id"": ""327c69c0-2375-4435-981d-5ad83cec819b"",
                    ""path"": ""2DVector(mode=1)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveKeypad"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""598f6f28-460e-42d9-b037-736e9a3256fe"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveKeypad"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""9bbbb04f-06de-4b57-b139-fae30765e41b"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveKeypad"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""068f1d06-bb33-4d0c-93a0-2185ec7d919e"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveKeypad"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""f3102382-27cd-4654-805c-0d7343729fe6"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveKeypad"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""2dfaeb9e-c695-4721-a575-a929b2782692"",
                    ""path"": ""2DVector(mode=1)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveWASD"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""d4a26284-a877-4bb8-8da8-74591c59e4b6"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveWASD"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""00232db5-0fd9-4f4f-9de3-19ff6fa40a21"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveWASD"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""2b5bfa9b-4d55-4f74-bbfe-407685b79379"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveWASD"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""d03a491a-21a9-40a8-b46a-3878d45f829f"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveWASD"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""ArrowButtons"",
                    ""id"": ""90c889c4-3d46-4546-b6a0-e8f182a75225"",
                    ""path"": ""2DVector(mode=1)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveWASD"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""209e88ad-c512-439d-97a2-e2c27d9656f1"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveWASD"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""fe4e0672-dcb5-49bf-86db-218541c75ea7"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveWASD"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""4b789cce-c9b4-446b-80d3-906a243750b6"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveWASD"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""abf34c4d-8852-4d50-a870-149807dbf8f7"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveWASD"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Controls
        m_Controls = asset.FindActionMap("Controls", throwIfNotFound: true);
        m_Controls_MoveAWEF = m_Controls.FindAction("MoveAWEF", throwIfNotFound: true);
        m_Controls_MoveKeypad = m_Controls.FindAction("MoveKeypad", throwIfNotFound: true);
        m_Controls_MoveWASD = m_Controls.FindAction("MoveWASD", throwIfNotFound: true);
        m_Controls_Grab = m_Controls.FindAction("Grab", throwIfNotFound: true);
        m_Controls_RotateCamera = m_Controls.FindAction("RotateCamera", throwIfNotFound: true);
        m_Controls_PauseMenu = m_Controls.FindAction("PauseMenu", throwIfNotFound: true);
        m_Controls_Undo = m_Controls.FindAction("Undo", throwIfNotFound: true);
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

    // Controls
    private readonly InputActionMap m_Controls;
    private IControlsActions m_ControlsActionsCallbackInterface;
    private readonly InputAction m_Controls_MoveAWEF;
    private readonly InputAction m_Controls_MoveKeypad;
    private readonly InputAction m_Controls_MoveWASD;
    private readonly InputAction m_Controls_Grab;
    private readonly InputAction m_Controls_RotateCamera;
    private readonly InputAction m_Controls_PauseMenu;
    private readonly InputAction m_Controls_Undo;
    public struct ControlsActions
    {
        private @ControlsManager m_Wrapper;
        public ControlsActions(@ControlsManager wrapper) { m_Wrapper = wrapper; }
        public InputAction @MoveAWEF => m_Wrapper.m_Controls_MoveAWEF;
        public InputAction @MoveKeypad => m_Wrapper.m_Controls_MoveKeypad;
        public InputAction @MoveWASD => m_Wrapper.m_Controls_MoveWASD;
        public InputAction @Grab => m_Wrapper.m_Controls_Grab;
        public InputAction @RotateCamera => m_Wrapper.m_Controls_RotateCamera;
        public InputAction @PauseMenu => m_Wrapper.m_Controls_PauseMenu;
        public InputAction @Undo => m_Wrapper.m_Controls_Undo;
        public InputActionMap Get() { return m_Wrapper.m_Controls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ControlsActions set) { return set.Get(); }
        public void SetCallbacks(IControlsActions instance)
        {
            if (m_Wrapper.m_ControlsActionsCallbackInterface != null)
            {
                @MoveAWEF.started -= m_Wrapper.m_ControlsActionsCallbackInterface.OnMoveAWEF;
                @MoveAWEF.performed -= m_Wrapper.m_ControlsActionsCallbackInterface.OnMoveAWEF;
                @MoveAWEF.canceled -= m_Wrapper.m_ControlsActionsCallbackInterface.OnMoveAWEF;
                @MoveKeypad.started -= m_Wrapper.m_ControlsActionsCallbackInterface.OnMoveKeypad;
                @MoveKeypad.performed -= m_Wrapper.m_ControlsActionsCallbackInterface.OnMoveKeypad;
                @MoveKeypad.canceled -= m_Wrapper.m_ControlsActionsCallbackInterface.OnMoveKeypad;
                @MoveWASD.started -= m_Wrapper.m_ControlsActionsCallbackInterface.OnMoveWASD;
                @MoveWASD.performed -= m_Wrapper.m_ControlsActionsCallbackInterface.OnMoveWASD;
                @MoveWASD.canceled -= m_Wrapper.m_ControlsActionsCallbackInterface.OnMoveWASD;
                @Grab.started -= m_Wrapper.m_ControlsActionsCallbackInterface.OnGrab;
                @Grab.performed -= m_Wrapper.m_ControlsActionsCallbackInterface.OnGrab;
                @Grab.canceled -= m_Wrapper.m_ControlsActionsCallbackInterface.OnGrab;
                @RotateCamera.started -= m_Wrapper.m_ControlsActionsCallbackInterface.OnRotateCamera;
                @RotateCamera.performed -= m_Wrapper.m_ControlsActionsCallbackInterface.OnRotateCamera;
                @RotateCamera.canceled -= m_Wrapper.m_ControlsActionsCallbackInterface.OnRotateCamera;
                @PauseMenu.started -= m_Wrapper.m_ControlsActionsCallbackInterface.OnPauseMenu;
                @PauseMenu.performed -= m_Wrapper.m_ControlsActionsCallbackInterface.OnPauseMenu;
                @PauseMenu.canceled -= m_Wrapper.m_ControlsActionsCallbackInterface.OnPauseMenu;
                @Undo.started -= m_Wrapper.m_ControlsActionsCallbackInterface.OnUndo;
                @Undo.performed -= m_Wrapper.m_ControlsActionsCallbackInterface.OnUndo;
                @Undo.canceled -= m_Wrapper.m_ControlsActionsCallbackInterface.OnUndo;
            }
            m_Wrapper.m_ControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MoveAWEF.started += instance.OnMoveAWEF;
                @MoveAWEF.performed += instance.OnMoveAWEF;
                @MoveAWEF.canceled += instance.OnMoveAWEF;
                @MoveKeypad.started += instance.OnMoveKeypad;
                @MoveKeypad.performed += instance.OnMoveKeypad;
                @MoveKeypad.canceled += instance.OnMoveKeypad;
                @MoveWASD.started += instance.OnMoveWASD;
                @MoveWASD.performed += instance.OnMoveWASD;
                @MoveWASD.canceled += instance.OnMoveWASD;
                @Grab.started += instance.OnGrab;
                @Grab.performed += instance.OnGrab;
                @Grab.canceled += instance.OnGrab;
                @RotateCamera.started += instance.OnRotateCamera;
                @RotateCamera.performed += instance.OnRotateCamera;
                @RotateCamera.canceled += instance.OnRotateCamera;
                @PauseMenu.started += instance.OnPauseMenu;
                @PauseMenu.performed += instance.OnPauseMenu;
                @PauseMenu.canceled += instance.OnPauseMenu;
                @Undo.started += instance.OnUndo;
                @Undo.performed += instance.OnUndo;
                @Undo.canceled += instance.OnUndo;
            }
        }
    }
    public ControlsActions @Controls => new ControlsActions(this);
    public interface IControlsActions
    {
        void OnMoveAWEF(InputAction.CallbackContext context);
        void OnMoveKeypad(InputAction.CallbackContext context);
        void OnMoveWASD(InputAction.CallbackContext context);
        void OnGrab(InputAction.CallbackContext context);
        void OnRotateCamera(InputAction.CallbackContext context);
        void OnPauseMenu(InputAction.CallbackContext context);
        void OnUndo(InputAction.CallbackContext context);
    }
}
