using System;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Animator))]
public class NPCMaskedGhoul : Collidable
{
    private AudioSource audioSource;
    private Animator animator;
    public UnityEvent OnTouch;
    private bool isAlive = true;

    protected override void Awake()
    {
        base.Awake();
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }


    protected override void OnCollide(Collider2D collider)
    {
        if (!isAlive)
        {
            return;
        }

        if (collider.CompareTag("Player"))
        {
            Debug.Log("Player Hit Masked Ghoul");
            isAlive = false;
            animator.SetTrigger("OnMelt");
            audioSource.Play();
            OnTouch.Invoke();
            Invoke(nameof(DelayedDestroyed), 3f);
        }
    }

    private void DelayedDestroyed()
    {
        
        Destroy(gameObject);
    }
}
