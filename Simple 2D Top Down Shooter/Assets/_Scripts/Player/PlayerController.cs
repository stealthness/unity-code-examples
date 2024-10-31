using _Scripts.Core;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _Scripts.Player
{
    
    public class PlayerController : MonoBehaviour
    {
        
        private Weapon _weapon;
        private PlayerMovement _playerMovement;
        
        private void Awake()
        {
            _weapon = GetComponentInChildren<Weapon>();
            _playerMovement = GetComponent<PlayerMovement>();
        }

        
        public void OnFire(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                Debug.Log("Fire");
                _weapon.Fire();
            }
        }
        
        public void OnMove(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                _playerMovement.SetMovementDirection(context.ReadValue<Vector2>());
            } else if (context.canceled)
            {
                _playerMovement.SetMovementDirection(Vector2.zero);
            }
            
        }

    }    


}