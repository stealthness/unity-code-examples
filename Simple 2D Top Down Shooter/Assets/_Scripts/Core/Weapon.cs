using UnityEngine;
using UnityEngine.InputSystem;

namespace _Scripts.Core
{
    public class Weapon : MonoBehaviour
    {
        public Camera mainCamera;
        private InputAction aimAction;
        private PlayerInput playerInput;

        private void Awake()
        {
            playerInput = GetComponentInParent<PlayerInput>();
            aimAction = playerInput.actions["Look"];
        }


        // Update is called once per frame
        void Update()
        {
            Vector3 mouseScreenPosition = aimAction.ReadValue<Vector2>();
            
            Vector3 mouseWorldPosition = mainCamera.ScreenToWorldPoint(new Vector3(mouseScreenPosition.x, mouseScreenPosition.y, mainCamera.nearClipPlane));

            // Calculate direction from gun to mouse position
            Vector3 directionToMouse = mouseWorldPosition - transform.position;
            directionToMouse.z = 0; // Keep rotation in the x-y plane for 2D or x-z for 3D

            // Rotate the gun to look at the mouse position
            float angle = Mathf.Atan2(directionToMouse.y, directionToMouse.x) * Mathf.Rad2Deg;
            transform.position = transform.position +  directionToMouse.normalized * 0.5f;
            transform.rotation = Quaternion.Euler(0f, 0f, angle);
        }
        

    }
}
