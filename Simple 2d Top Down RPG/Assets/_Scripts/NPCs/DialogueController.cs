using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace _Scripts.NPCs
{
    public class DialogueController: MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI NPCName;
        [SerializeField] private TextMeshProUGUI dialogueText;

        private Queue<string> _paragraphs;
        private bool conversationEnded = false;


        private void Start()
        {
            _paragraphs = new Queue<string>();
        }

        public void ShowNextParagraph(DialogueSo dialogue)
        {
            Debug.Log("ShowNextParagraph: " + dialogue.speakerName + " " + dialogue.dialogue.Length);
            
            if (!conversationEnded)
            {
                StartConversation(dialogue);
            }
            else
            {
                EndConversation();
            }
        }

        private void StartConversation(DialogueSo dialogue)
        {

            if (!gameObject.activeSelf)
            {
                gameObject.SetActive(true);            
                NPCName.text = dialogue.speakerName;
                _paragraphs = new Queue<string>();
               foreach (var line in dialogue.dialogue)
               {
                   _paragraphs.Enqueue(line);
               }
            }
            if (_paragraphs.Count == 0)
            {
                Debug.Log("End of conversation");
                conversationEnded = true;
                return;
            }
            Debug.Log("ShowNextParagraph: " + _paragraphs.Count);
            dialogueText.text = _paragraphs.Dequeue();

            
 
        }

        private void EndConversation()
        {
            gameObject.SetActive(false);
            conversationEnded = true;
        }

        public void ResetDialogue()
        {
            _paragraphs.Clear();
            gameObject.SetActive(false);
            conversationEnded = true;
        }

        public void HideDialogue()
        {
            _paragraphs.Clear();
            gameObject.SetActive(false);
            conversationEnded = true;
        }
    }
}