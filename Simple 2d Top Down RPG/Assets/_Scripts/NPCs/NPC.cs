using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _Scripts.NPCs
{
    public abstract class NPC : MonoBehaviour, IInteractable
    {

        [SerializeField] protected SpriteRenderer interactionSprite;

        private void Start()
        {
            interactionSprite.enabled = false;
        }

        private void Update()
        {
            if (Keyboard.current.spaceKey.wasPressedThisFrame)
            {
                Interact();
            }
        }

        public abstract void Interact();


        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                interactionSprite.enabled = true;
            }
        }
        
        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                interactionSprite.enabled = false;
            }
        }
    }
}