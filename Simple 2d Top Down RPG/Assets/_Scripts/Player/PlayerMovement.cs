using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerMovement : Movement
{
    [SerializeField] private string[] _layers = new string[] { "Blocking" };
    private Animator _animator;
    private PlayerController _playerController;
    private RaycastHit2D _hit;
    private const float FadeDuration = 3f;

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
        Vector2 dir = _playerController.MoveDir;
        if (_playerController.MoveDir != Vector2.zero && CheckMove(dir)) 
        {
            _animator.SetBool("IsMoving", true);
            MoveDir(dir);
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
    private bool CheckMove(Vector2 dir)
    {
        int layerMasks = LayerMask.GetMask(_layers);
        if (Mathf.Abs(dir.y) > 0)
        {
            _hit = Physics2D.BoxCast(transform.position, ((BoxCollider2D)_box).size, 0, new Vector2(0, dir.y), Mathf.Abs(dir.y * Time.deltaTime * _speed), layerMasks);
            if (_hit.collider != null)
            {
                return false;
            }
        }
        
        if (Mathf.Abs(dir.x) > 0)
        {
            _hit = Physics2D.BoxCast(transform.position, ((BoxCollider2D)_box).size, 0, new Vector2(dir.x, 0), Mathf.Abs(dir.x * Time.deltaTime * _speed), layerMasks);
            if (_hit.collider != null)
            {
                return false;
            }
        }
        
        return true;
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
