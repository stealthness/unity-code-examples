using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

namespace _Scripts
{
    
    [RequireComponent(typeof(AudioSource))]
    public class MouseClickDetection : MonoBehaviour
    {
        public InputActionAsset inputActionAsset;
        public AudioClip clickSelectedClip;
        public AudioClip clickDeselectedClip;
        
        private InputAction _mouseClickAction;
        private Camera _mainCamera;
        private AudioSource _audioSource;
        
        
        public void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
            _mainCamera = Camera.main;
            _mouseClickAction = inputActionAsset.FindActionMap("ClickerControls").FindAction("MouseClick");

        }

        private void OnEnable()
        {
            _mouseClickAction.Enable();
        }

        private void OnDisable()
        {
            _mouseClickAction.Disable();
        }

        private void Update()
        {
            if (_mouseClickAction.triggered)
            {
                Debug.Log("Mouse Clicked");
                DetectIfTargetClicked();
            }
        }

        private void DetectIfTargetClicked()
        {
            Vector2 point = _mainCamera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            var overlapPoint = Physics2D.OverlapPoint(point);
            
            if (overlapPoint && overlapPoint.CompareTag("Target"))
            {
                if (overlapPoint.TryGetComponent<Target>(out var target))
                {
                    _audioSource.PlayOneShot(clickSelectedClip);
                    target.DestroyTarget();
                }
            }
            else
            {
                _audioSource.PlayOneShot(clickDeselectedClip);
            }

        }
    }
}