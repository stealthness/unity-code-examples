using UnityEngine;
using UnityEngine.InputSystem;

namespace _Scripts
{
    public class MouseClickDetection : MonoBehaviour
    {
        public InputActionAsset inputActionAsset;
        private InputAction mouseClickAction;
        private Camera mainCamera;
        
        public void Awake()
        {
            mainCamera = Camera.main;
            inputActionAsset = ScriptableObject.CreateInstance<InputActionAsset>();
            mouseClickAction = inputActionAsset.FindActionMap("ClickerControls").FindAction("MouseClick");
        }
        
        void OnEnable()
        {
            mouseClickAction.Enable();
        }
        
        void OnDisable()
        {
            mouseClickAction.Disable();
        }
        
        void Update()
        {
            if (mouseClickAction.triggered)
            {
                Debug.Log("Mouse Clicked");
                DetectIfTargetClicked();
            }
        }

        private void DetectIfTargetClicked()
        {
            Ray ray = mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
            RaycastHit hit;
            
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("Target"))
                {
                    GameManager.Instance.OnTargetHit(hit.collider.gameObject);
                }
            }
        }
    }
}