using _Scripts.Enemy;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _Scripts.Core
{
    public class Weapon : MonoBehaviour
    {
        public GameObject bulletPrefab;
        
        public Camera mainCamera;
        private InputAction aimAction;
        private PlayerInput playerInput;
        private Vector3 _currentMouseScreenPosition;
        private Vector3 _directionToMouse;

        private const float Tol = 10e-6f;
        
        
        private void Awake()
        {
            playerInput = GetComponentInParent<PlayerInput>();
            aimAction = playerInput.actions["Aim"];
        }


        // Update is called once per frame
        void Update()
        {
            Vector3 mouseScreenPosition = Vector3.zero;

            if (aimAction.triggered)
            {
                UpdateRotate(aimAction.ReadValue<Vector2>());
            }

        }


        private void UpdateRotate(Vector2 mousePosition)
        {
            Vector3 mouseWorldPosition = mainCamera.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, mainCamera.nearClipPlane));
            mouseWorldPosition.z = 0;
            
            // Calculate direction from player (parent) to mouse position
            _directionToMouse = (mouseWorldPosition - transform.parent.position).normalized;
            
            
            // Rotate the gun around the player to look at the mouse position
            float angle = Mathf.Atan2(_directionToMouse.y, _directionToMouse.x) * Mathf.Rad2Deg;
            transform.position = transform.parent.position +  _directionToMouse * 0.5f;
            transform.rotation = Quaternion.Euler(0f, 0f, angle);
            
            //Debug.Log($"mWP: {mousePosition}, dTM: {directionToMouse}, angle: {angle}");
        }
        
        public void Fire()
        {
                Debug.Log("Fire");
                var bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                bullet.GetComponent<Bullet>().SetDirection(_directionToMouse);
        }

    }
}