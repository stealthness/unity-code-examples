using System.Collections;
using UnityEngine;

/// <summary>
/// Player Movement class is extension of Movement class
/// </summary>
[RequireComponent(typeof(Animator))]
public class PlayerMovement : Movement
{
    [SerializeField] private string[] _layers = new string[] { "Blocking" };
    private const float FadeDuration = 3f;
    private Animator _animator;
    private PlayerController _playerController;
    private RaycastHit2D _hit;
    private Vector2 _moveDir;

    protected override void Awake()
    {
        base.Awake();
        _animator = GetComponent<Animator>();
        _playerController = GetComponent<PlayerController>();
    }

     private void Start()
    {
        _speed = 5f;
    }

    private void Update()
    {
        _moveDir = _playerController.MoveDir;
        if (_playerController.MoveDir != Vector2.zero && CheckMove()) 
        {
            _animator.SetBool("IsMoving", true);
            MoveDir(_moveDir);
        }
        else
        {
            _animator.SetBool("IsMoving", false);
        }
    }

    /// <summary>
    /// Checks collision using box cast
    /// Note: remember to change settings of Physics2D to uncheck "queires start in collider"
    /// </summary>
    /// <returns></returns>
    private bool CheckMove()
    {
        int layerMasks = LayerMask.GetMask(_layers);
        if (Mathf.Abs(_moveDir.y) > 0)
        {
            _hit = Physics2D.BoxCast(transform.position, ((BoxCollider2D)_box).size, 0, new Vector2(0, _moveDir.y), Mathf.Abs(_moveDir.y * Time.deltaTime * _speed), layerMasks);
            if (_hit.collider != null)
            {
                _moveDir.y = 0;
            }
        }
        
        if (Mathf.Abs(_moveDir.x) > 0)
        {
            _hit = Physics2D.BoxCast(transform.position, ((BoxCollider2D)_box).size, 0, new Vector2(_moveDir.x, 0), Mathf.Abs(_moveDir.x * Time.deltaTime * _speed), layerMasks);
            if (_hit.collider != null)
            {
                _moveDir.x = 0;
            }
        }

        return _moveDir != Vector2.zero;
    }


    public void FadePlayer()
    {
        StartCoroutine(FadeObject());
    }

    IEnumerator FadeObject()
    {

        Color startColor = _sr.material.color;

        // Set the target color with initial alpha set to 0
        Color targetColor = new Color(startColor.r, startColor.g, startColor.b, 0f);

        // Time elapsed during the fade
        float currentTime = 0.0f;

        while (currentTime < FadeDuration)
        {

            currentTime += Time.deltaTime;
            float lerpFactor = currentTime / FadeDuration;
            _sr.material.color = Color.Lerp(startColor, targetColor, lerpFactor);

            // Wait for the next frame
            yield return null;
        }

        // Ensure the final color is set
        _sr.material.color = targetColor;
        Destroy(gameObject);


    }

}
