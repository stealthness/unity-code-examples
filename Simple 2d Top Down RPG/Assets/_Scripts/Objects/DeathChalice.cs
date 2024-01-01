using UnityEngine;
using UnityEngine.Events;

public class DeathChalice : Collidable
{

    public UnityEvent OnTouch;

    protected override void OnCollide(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            Debug.Log("Player Hit death Chalice");
            _isCollidable = false;
            OnTouch.Invoke();
        }
    }
}
