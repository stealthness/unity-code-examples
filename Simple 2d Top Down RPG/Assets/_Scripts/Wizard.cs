using TMPro;
using UnityEngine;
namespace _Scripts
{
    public class Wizard : NPCs.NPC
    {
        public TextMeshProUGUI chatText;
        private float _minChatDelayExit = 2f;
        private Camera _camera;

        private void Start()
        {
            _camera = Camera.main;
            
        }
        

        public override void Interact()
        {
            Talk(dialogue);
        }
        
        
        private void OnTriggerExit2D(Collider2D other)
        {
            base.OnTriggerExit2D(other);
            if (other.CompareTag("Player"))
            {
                dialogueController.HideDialogue();
                dialogue.ResetIndex();
            }
        }

        


    }
}
