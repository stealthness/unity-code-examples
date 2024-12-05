using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Animator))]
public class NPCMaskedGhoul : Collidable
{
    public UnityEvent OnTouch;

    private const float DelayedDestructionTimer = 3f;
    private bool _isAlive = true;
    private AudioSource _audioSource;
    private Animator _animator;

    protected override void Awake()
    {
        base.Awake();
        _audioSource = GetComponent<AudioSource>();
        _animator = GetComponent<Animator>();
    }


    protected override void OnCollide(Collider2D collider)
    {
        if (!_isAlive)
        {
            return;
        }

        if (collider.CompareTag("Player"))
        {
            Debug.Log("Player Hit Masked Ghoul");
            _isAlive = false;
            _animator.SetTrigger("OnMelt");
            _audioSource.Play();
            OnTouch.Invoke();
            Invoke(nameof(DelayedDestroyed), DelayedDestructionTimer);
        }
    }

    private void DelayedDestroyed()
    {
        
        Destroy(gameObject);
    }
}
