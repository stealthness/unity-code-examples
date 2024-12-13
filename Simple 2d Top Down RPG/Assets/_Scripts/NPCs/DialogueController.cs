using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace _Scripts.NPCs
{
    public class DialogueController: MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI npcNameText;
        [SerializeField] private TextMeshProUGUI npcDialogueText;
        [SerializeField] private float typingSpeed = 0.1f;

        private Queue<string> _paragraphs = new Queue<string>();
        private bool _conversationEnded = false;


        private Coroutine _dialogueTyping;
        private bool _isTyping = false;

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

            var text = _paragraphs.Dequeue();

            if (!_isTyping)
            {
                _dialogueTyping = StartCoroutine(TypeText(text));
            }
            
            
            if (_paragraphs.Count == 0)
            {
                _conversationEnded = true;
            }
            
        }

        private IEnumerator TypeText(string text)    
        {
            _isTyping = true;
            npcDialogueText.text = "";
            string originalText = text;
            string displayText = "";
            int alphaIndex = 0;
            
            string HTML_ALTHPA = "<color=#00000000>";
            
            foreach (var letter in text.ToCharArray())
            {
                alphaIndex++;
                npcDialogueText.text = originalText;
                displayText = npcDialogueText.text.Insert(alphaIndex, HTML_ALTHPA);
                npcDialogueText.text = displayText;
                yield return new WaitForSeconds(typingSpeed);
            }

            _isTyping = false;
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