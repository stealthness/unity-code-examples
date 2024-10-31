using _Scripts.Core;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _Scripts.Player
{
    
    /// <summary>
    /// This class is responsible for handling player input and delegating it to the appropriate components.
    /// </summary>
    public class PlayerController : MonoBehaviour
    {
        /// <summary>
        /// A reference to the Weapon component
        /// </summary>
        private Weapon _weapon;
        /// <summary>
        /// A reference to the PlayerMovement component
        /// </summary>
        private PlayerMovement _playerMovement;
        /// <summary>
        /// A reference to the BoxCollider2D component
        /// </summary>
        private BoxCollider2D _boxCollider2D;
        
        /// <summary>
        /// Set up the references to the components
        /// </summary>
        private void Awake()
        {
            _boxCollider2D = GetComponent<BoxCollider2D>();
            _weapon = GetComponentInChildren<Weapon>();
            _playerMovement = GetComponent<PlayerMovement>();
        }

        /// <summary>
        /// Is called when the player presses the fire button
        /// </summary>
        /// <param name="context"></param>
        public void OnFire(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                Debug.Log("Fire");
                _weapon.Fire();
            }
        }
        
        /// <summary>
        /// Is called when the player presses the move button and sets the movement direction of the player, or sets it
        /// to zero if the player stops pressing the move button
        /// </summary>
        /// <param name="context"></param>
        public void OnMove(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                // If the player is pressing the move button, set the movement direction to the value of the context
                _playerMovement.SetMovementDirection(context.ReadValue<Vector2>());
            } else if (context.canceled)
            {
                // If the player stops pressing the move button, set the movement direction to zero
                _playerMovement.SetMovementDirection(Vector2.zero);
            }
        }
        

        


    }    


}