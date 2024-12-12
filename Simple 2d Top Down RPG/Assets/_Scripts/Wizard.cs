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

        // private void Update()
        // {
        //     if (chatText.enabled)
        //     {
        //         chatText.transform.position = _camera.WorldToScreenPoint(transform.position + Vector3.up * 2);
        //
        //     }
        // }

        public override void Interact()
        {
            StartChat();
        }
        
        
        // private void OnTriggerEnter2D(Collider2D other)
        // {
        //     if (other.CompareTag("Player"))
        //     {
        //         StartChat();
        //     }
        // }
        //
        private void OnTriggerExit2D(Collider2D other)
        {
            base.OnTriggerExit2D(other);
            if (other.CompareTag("Player"))
            {
                EndChat();
            }
        }
        
        private void StartChat()
        {
            chatText.text = "Hello Bob, I am Wizard!";
            chatText.enabled = true;
            Invoke(nameof(DisableChat), _minChatDelayExit);
        }
        
        private void EndChat()
        {
            if (chatText.enabled)
            {
                chatText.text = "Good bye Bob!";
                Invoke(nameof(DisableChat), _minChatDelayExit);
            }
        }
        
        private void DisableChat()
        {
            chatText.enabled = false;
        }
    }
}
