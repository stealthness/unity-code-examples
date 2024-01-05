using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Animator))]
public class Portal : Collidable
{
    public UnityEvent OnPlayerTouch;
    public bool IsIdleDefault = true;
    public bool IsIdlePulse = false;
    public bool IsIdleObit = false;

    private Animator _animator;


    protected override void Awake()
    {
        base.Awake();
        _box.isTrigger = true;
        _animator = GetComponent<Animator>();
    }


    private void Start()
    {

        if (IsIdlePulse)
        {
            _animator.SetBool("IsIdlePulsing", true);
        }
        else if (IsIdleObit)
        {
            _animator.SetBool("IsIdleOrbit", true);
        }
        else
        {
            _animator.SetBool("IsIdlePulsing", false);
            _animator.SetBool("IsIdleOrbit", false);
        }
    }


    protected override void OnCollide(Collider2D collider)
    {
        if (!_isCollidable)
        {
            return;
        }

        if (collider.CompareTag("Player"))
        {
            Debug.Log("Player Hit Portal");
            _isCollidable = false;
            OnPlayerTouch.Invoke();
        }
    }

    protected override void OnCollideEnter(Collider2D collider)
    {
        base.OnCollideEnter(collider);

        Debug.Log("Portal: OnCollideEnter");
    }
    protected override void OnCollideExit(Collider2D collider)
    {
        base.OnCollideExit(collider);

        Debug.Log("Portal: OnCollideExit");
    }
}
