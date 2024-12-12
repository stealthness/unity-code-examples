using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Scripts
{
    public class Wizard : MonoBehaviour
    {
        public TextMeshProUGUI chatText;
        private float _minChatDelayExit = 2f;
        
        private Camera _camera;

        private void Start()
        {
            _camera = Camera.main;
        }

        private void Update()
        {
            if (chatText.enabled)
            {

                chatText.transform.position = _camera.WorldToScreenPoint(transform.position + Vector3.up * 2);

            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                StartChat();
            }
        }



        private void StartChat()
        {
            chatText.text = "Hello Bob, I am Wizard!";
            chatText.enabled = true;
            Invoke(nameof(DisableChat), _minChatDelayExit);
        }
        
        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                EndChat();
            }
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
