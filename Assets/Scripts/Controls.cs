// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Controls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""Fence"",
            ""id"": ""c3847487-2d27-4e39-85df-b764d9d99f37"",
            ""actions"": [
                {
                    ""name"": ""slash"",
                    ""type"": ""Button"",
                    ""id"": ""28674a3a-cd8a-421d-a5fa-c230cd9abae6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Antislash"",
                    ""type"": ""Button"",
                    ""id"": ""09fac1c8-6665-4651-aada-92d9092bd792"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""New action"",
                    ""type"": ""Value"",
                    ""id"": ""4fe027c8-5b6d-4b70-a355-5763ad09c3d2"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Drop"",
                    ""type"": ""Button"",
                    ""id"": ""b4ead908-7917-4aa4-ad50-7e259f6c55ff"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""592dce5b-2da2-4b94-8e94-906162c6e560"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""slash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""23f68016-f039-4053-a14e-3550448fa7fe"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Antislash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fd84f990-a24e-4cfc-b57b-f29c9dbbf902"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""New action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3e2c3473-8ef4-4a4e-a830-820f6ef4af7a"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Drop"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Fence
        m_Fence = asset.FindActionMap("Fence", throwIfNotFound: true);
        m_Fence_slash = m_Fence.FindAction("slash", throwIfNotFound: true);
        m_Fence_Antislash = m_Fence.FindAction("Antislash", throwIfNotFound: true);
        m_Fence_Newaction = m_Fence.FindAction("New action", throwIfNotFound: true);
        m_Fence_Drop = m_Fence.FindAction("Drop", throwIfNotFound: true);
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

    // Fence
    private readonly InputActionMap m_Fence;
    private IFenceActions m_FenceActionsCallbackInterface;
    private readonly InputAction m_Fence_slash;
    private readonly InputAction m_Fence_Antislash;
    private readonly InputAction m_Fence_Newaction;
    private readonly InputAction m_Fence_Drop;
    public struct FenceActions
    {
        private @Controls m_Wrapper;
        public FenceActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @slash => m_Wrapper.m_Fence_slash;
        public InputAction @Antislash => m_Wrapper.m_Fence_Antislash;
        public InputAction @Newaction => m_Wrapper.m_Fence_Newaction;
        public InputAction @Drop => m_Wrapper.m_Fence_Drop;
        public InputActionMap Get() { return m_Wrapper.m_Fence; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(FenceActions set) { return set.Get(); }
        public void SetCallbacks(IFenceActions instance)
        {
            if (m_Wrapper.m_FenceActionsCallbackInterface != null)
            {
                @slash.started -= m_Wrapper.m_FenceActionsCallbackInterface.OnSlash;
                @slash.performed -= m_Wrapper.m_FenceActionsCallbackInterface.OnSlash;
                @slash.canceled -= m_Wrapper.m_FenceActionsCallbackInterface.OnSlash;
                @Antislash.started -= m_Wrapper.m_FenceActionsCallbackInterface.OnAntislash;
                @Antislash.performed -= m_Wrapper.m_FenceActionsCallbackInterface.OnAntislash;
                @Antislash.canceled -= m_Wrapper.m_FenceActionsCallbackInterface.OnAntislash;
                @Newaction.started -= m_Wrapper.m_FenceActionsCallbackInterface.OnNewaction;
                @Newaction.performed -= m_Wrapper.m_FenceActionsCallbackInterface.OnNewaction;
                @Newaction.canceled -= m_Wrapper.m_FenceActionsCallbackInterface.OnNewaction;
                @Drop.started -= m_Wrapper.m_FenceActionsCallbackInterface.OnDrop;
                @Drop.performed -= m_Wrapper.m_FenceActionsCallbackInterface.OnDrop;
                @Drop.canceled -= m_Wrapper.m_FenceActionsCallbackInterface.OnDrop;
            }
            m_Wrapper.m_FenceActionsCallbackInterface = instance;
            if (instance != null)
            {
                @slash.started += instance.OnSlash;
                @slash.performed += instance.OnSlash;
                @slash.canceled += instance.OnSlash;
                @Antislash.started += instance.OnAntislash;
                @Antislash.performed += instance.OnAntislash;
                @Antislash.canceled += instance.OnAntislash;
                @Newaction.started += instance.OnNewaction;
                @Newaction.performed += instance.OnNewaction;
                @Newaction.canceled += instance.OnNewaction;
                @Drop.started += instance.OnDrop;
                @Drop.performed += instance.OnDrop;
                @Drop.canceled += instance.OnDrop;
            }
        }
    }
    public FenceActions @Fence => new FenceActions(this);
    public interface IFenceActions
    {
        void OnSlash(InputAction.CallbackContext context);
        void OnAntislash(InputAction.CallbackContext context);
        void OnNewaction(InputAction.CallbackContext context);
        void OnDrop(InputAction.CallbackContext context);
    }
}
