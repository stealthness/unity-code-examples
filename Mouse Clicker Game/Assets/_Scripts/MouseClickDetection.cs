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
            Vector2 point = mainCamera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            var collider = Physics2D.OverlapPoint(point);
            
            if (collider != null)
            {
                Debug.Log("Clicked on: " + collider.name);
                // You can add more logic here to handle the clicked object
                if (collider.CompareTag("Target"))
                {
                    Debug.Log("Target clicked!");
                    collider.GetComponent<Target>().DestroyTarget();
                    // Handle target click logic here
                }
                else
                {
                    Debug.Log("Clicked on a different object: " + collider.name);
                }
            }
            else
            {
                Debug.Log("Clicked on empty space");
            }

        }
    }
}