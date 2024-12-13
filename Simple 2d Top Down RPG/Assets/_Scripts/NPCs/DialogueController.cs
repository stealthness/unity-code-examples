using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace _Scripts.NPCs
{
    public class DialogueController: MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI npcNameText;
        [SerializeField] private TextMeshProUGUI npcDialogueText;

        private Queue<string> _paragraphs = new Queue<string>();
        private bool _conversationEnded = false;



        private void Start()
        {
            _paragraphs = new Queue<string>();
        }

        public void ShowNextParagraph(DialogueSo dialogue)
        {
            if (_paragraphs == null)
            {
                _paragraphs = new Queue<string>();
            }

            if (_paragraphs.Count == 0)
            {
                if (!_conversationEnded)
                {
                    StartConversation(dialogue);
                }
                else
                {
                    EndConversation();
                    return;
                }
            }
            
            npcDialogueText.text = _paragraphs.Dequeue();
            
            if (_paragraphs.Count == 0)
            {
                _conversationEnded = true;
            }
            
        }

        private void StartConversation(DialogueSo dialogue)
        {
            if (!gameObject.activeSelf)
            {
                gameObject.SetActive(true);
            }
            
            _conversationEnded = false;
            npcNameText.text = dialogue.speakerName;
            _paragraphs = new Queue<string>();
            
            foreach (var line in dialogue.dialogue)
            {
                _paragraphs.Enqueue(line);
            }

            
 
        }

        private void EndConversation()
        {
            _paragraphs.Clear();
            gameObject.SetActive(false);
            _conversationEnded = true;
        }

        public void ResetDialogue()
        {
            Debug.Log("ResetDialogue");
            if (_paragraphs != null)
            {
               _paragraphs.Clear();
            }
 
            gameObject.SetActive(false);
            _conversationEnded = false;
        }

        public void HideDialogue()
        {
            Debug.Log("HideDialogue");
            gameObject.SetActive(false);
        }
    }
}