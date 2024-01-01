using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider2D))]
public class Portal : Collidable
{
    public UnityEvent OnPlayerTouch;


    protected override void Awake()
    {
        base.Awake();
        _box.isTrigger = true;
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


}
