using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class Movement : MonoBehaviour
{
    internal Collider2D _box;
    internal SpriteRenderer _sr;

    [SerializeField] protected float _speed = 1f;
    [SerializeField] protected bool _isDisableMovement = false;


    protected virtual void Awake()
    {
        _box = GetComponent<Collider2D>();
        _sr = GetComponent<SpriteRenderer>();
    }


    protected void MoveDir(Vector2 dir)
    {
        if (_isDisableMovement)
        {
            return;
        }

        transform.Translate(Time.deltaTime * dir * _speed);
        CheckFlipSprite(dir);
    }

    /// <summary>
    /// Check weather the Movement spite is need to be fliped based on the direction dir.x
    /// </summary>
    /// <param name="dir">objects movement directions</param>
    private void CheckFlipSprite(Vector2 dir)
    {
        // flip sprite if moving to left
        if (dir.x < 0)
        {
            _sr.flipX = true;
        }
        if (dir.x > 0)
        {
            _sr.flipX = false;
        }
        // dir.x == 0 do nougthing
    }

    public void OnDisableMovement()
    {
        _isDisableMovement = true;
    }
}
