using _Scripts.Dialogue;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _Scripts.NPCs
{
    public abstract class NPC : MonoBehaviour, IInteractable, ITalkable
    {

        public DialogueController dialogueController;
        [SerializeField] protected SpriteRenderer interactionSprite;
        [SerializeField] protected bool isInteractable = false;
        [SerializeField] protected DialogueScriptableObject dialogue;
        private void Start()
        {
            interactionSprite.enabled = false;
        }

        private void Update()
        {
            if (Keyboard.current.spaceKey.wasPressedThisFrame && isInteractable)
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
                isInteractable = true;
            }
        }
        
        protected void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                interactionSprite.enabled = false;
                isInteractable = false;
                dialogueController.ResetDialogue();
            }
        }

        public void Talk(DialogueScriptableObject dialogueScribtableObject)
        {
            dialogueController.ShowNextParagraph(dialogueScribtableObject);
        }
    }
}