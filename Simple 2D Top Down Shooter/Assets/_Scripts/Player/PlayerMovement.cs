using _Scripts.Core;
using UnityEngine;
using UnityEngine.InputSystem;


namespace _Scripts.Player
{
    public class PlayerMovement : Movement2D
    {
        
        private Weapon _weapon;
        
        private void Awake()
        {
            _weapon = GetComponentInChildren<Weapon>();
        }
        
        public void OnMove(InputAction.CallbackContext context)
        {
            MovementDirection = context.ReadValue<Vector2>();
        }
        
        public void OnFire(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                Debug.Log("Fire");
                _weapon.Fire();
            }
        }


    }

}

