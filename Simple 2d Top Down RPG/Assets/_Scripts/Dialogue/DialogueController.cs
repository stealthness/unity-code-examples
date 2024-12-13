using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace _Scripts.Dialogue
{
    public class DialogueController: MonoBehaviour
    {
        private const string HtmlAlpha = "<color=#00000000>";
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

        public void ShowNextParagraph(DialogueScriptableObject dialogue)
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
                else if (_conversationEnded && !_isTyping)
                {
                    EndConversation();
                    return;
                }
            }

            if (!_isTyping)
            {
                _dialogueTyping = StartCoroutine(TypeText(_paragraphs.Dequeue()));
            }
            else
            {
                CompleteTyping();
            }
            
            
            if (_paragraphs.Count == 0)
            {
                _conversationEnded = true;
            }
            
        }

        private IEnumerator TypeText(string originalText)    
        {
            _isTyping = true;
            npcDialogueText.text = "";
            int alphaIndex = 0;

            foreach (var letter in originalText.ToCharArray())
            {
                alphaIndex++;
                npcDialogueText.text = originalText;
                npcDialogueText.text = npcDialogueText.text.Insert(alphaIndex, HtmlAlpha);
                yield return new WaitForSeconds(typingSpeed);
            }

            _isTyping = false;
        }

        private void CompleteTyping()
        {
            StopCoroutine(_dialogueTyping);
            npcDialogueText.text = npcDialogueText.text.Replace(HtmlAlpha, "");
            _isTyping = false;
        }
        
        
        private void StartConversation(DialogueScriptableObject dialogue)
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