using UnityEngine;
namespace _Scripts
{
    public class Wizard : NPCs.NPC
    {



        public override void Interact()
        {
            Talk(dialogue);
        }
        
        
        private new void OnTriggerExit2D(Collider2D other)
        {
            base.OnTriggerExit2D(other);
            if (other.CompareTag("Player"))
            {
                dialogueController.ResetDialogue();
            }
        }

        


    }
}
