using UnityEngine;
using UnityEngine.InputSystem;

namespace _Scripts
{
    public class MouseClickDetection : MonoBehaviour
    {
        public InputActionAsset inputActionAsset;
        
        private InputAction _mouseClickAction;
        private Camera _mainCamera;
        
        public void Awake()
        {
            _mainCamera = Camera.main;
            _mouseClickAction = inputActionAsset.FindActionMap("ClickerControls").FindAction("MouseClick");

        }

        private void OnEnable()
        {
            _mouseClickAction.Enable();
        }

        private void OnDisable()
        {
            _mouseClickAction.Disable();
        }

        private void Update()
        {
            if (_mouseClickAction.triggered)
            {
                Debug.Log("Mouse Clicked");
                DetectIfTargetClicked();
            }
        }

        private void DetectIfTargetClicked()
        {
            Vector2 point = _mainCamera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            var overlapPoint = Physics2D.OverlapPoint(point);
            
            if (overlapPoint && overlapPoint.CompareTag("Target"))
            {
                if (overlapPoint.TryGetComponent<Target>(out Target target))
                {
                    target.DestroyTarget();
                }
            }

        }
    }
}